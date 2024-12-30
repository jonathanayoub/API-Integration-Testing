#region

using System.Collections;
using System.Reflection;
using ApiIntegrationTesting.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#endregion

namespace ApiIntegrationTesting.Tests;

/// <summary>
/// Create a new instance of the AdventureWorksDbContext for integration tests and optionally seed the database with test data.
/// </summary>
internal static class TestDatabaseFixture
{
    private const string ConnectionString =
        @"Data Source=127.0.0.1,1433;Initial Catalog=api-integration-testing;User Id=sa;Password=P@ssw0rd;Column Encryption Setting=enabled;TrustServerCertificate=True";

    public static AdventureWorksDbContext CreateContext()
    {
        var context = new AdventureWorksDbContext(
            new DbContextOptionsBuilder<AdventureWorksDbContext>()
                .UseSqlServer(ConnectionString)
                .Options
        );

        return context;
    }
    
    public static async Task ResetDatabase()
    {
        await using AdventureWorksDbContext context = CreateContext();
        await DeleteDatabaseData(context);
        await SeedTestData(context);
    }
    
    
    /// <summary>
    /// Seed the test data for the integration tests.
    /// This does not include large configuration data sets like Attributes, AttributeFeatures, DataSourceAttributes,
    /// DisciplineAttributes, TemplateAttributes
    /// </summary>
    private static async Task SeedTestData(AdventureWorksDbContext context)
    {
        await InsertWithoutIdentityInsert(
            context,
            ObjectCloningUtility.ShallowCloneArraySimpleTypes(AdventureWorksSeedData.CountryRegionEntities)
        );
        await DatabaseInsertUtility.InsertWithIdentityInsert(
            context,
            ObjectCloningUtility.ShallowCloneArraySimpleTypes(AdventureWorksSeedData.SalesTerritoryEntities)
        );
        await DatabaseInsertUtility.InsertWithIdentityInsert(
            context,
            ObjectCloningUtility.ShallowCloneArraySimpleTypes(AdventureWorksSeedData.StateProvinceEntities)
        );
        await DatabaseInsertUtility.InsertWithIdentityInsert(
            context,
            ObjectCloningUtility.ShallowCloneArraySimpleTypes(AdventureWorksSeedData.AddressEntities)
        );
    }
    
    /// <summary>
    /// Insert data into the database without IDENTITY_INSERT turned on for an entity that has no identity column.
    /// </summary>
    private static async Task InsertWithoutIdentityInsert<TEntity>(
        DbContext context,
        IEnumerable<TEntity> entities
    )
        where TEntity : class
    {
        context.Set<TEntity>().AddRange(entities);
    
        await context.SaveChangesAsync();
    }
    
    /// <summary>
    /// Delete all data in all of the tables in the database. Do this after each test run to ensure a clean slate for the next test run.
    /// </summary>
    private static async Task DeleteDatabaseData(AdventureWorksDbContext context)
    {
        await DeleteAllDataAsync(context);
        await ResetIdentityColumns(context);
    }
    
    /// <summary>
    /// Delete all data in all of the tables in the database, referencing each property in the DbContext explicitly.
    /// </summary>
    private static async Task DeleteAllDataAsync(AdventureWorksDbContext context)
    {
        List<PropertyInfo> dbSetProperties = context.GetType().GetProperties()
            .Where(p => p.PropertyType.IsGenericType && p.PropertyType.GetGenericTypeDefinition() == typeof(DbSet<>))
            .ToList();
        
        foreach (PropertyInfo dbSetProperty in dbSetProperties)
        {
            object dbSet = dbSetProperty.GetValue(context);
            if (dbSet == null) continue;
            
            Type entityType = dbSetProperty.PropertyType.GetGenericArguments().First();
            MethodInfo method = dbSet.GetType().GetMethod("RemoveRange", [typeof(IEnumerable<>).MakeGenericType(entityType)]);
            if (method == null) continue;
            
            method.Invoke(dbSet, [dbSet]);
        }
        
        await context.SaveChangesAsync();
    }
    
    /// <summary>
    /// Set the identity columns back to 0 for all tables that have an identity column.
    /// This is needed to reset the identity columns after deleting all data.
    /// </summary>
    private static async Task ResetIdentityColumns(AdventureWorksDbContext context)
    {
        IEnumerable<IEntityType> entityTypes = context.Model.GetEntityTypes();
        List<IEntityType> tablesWithIdentity = entityTypes
            .Where(e =>
                e.FindPrimaryKey()?.Properties.Any(p => p.ValueGenerated == ValueGenerated.OnAdd)
                == true
            )
            .ToList();
    
        foreach (IEntityType entityType in tablesWithIdentity)
        {
            string tableName = entityType.GetTableName();
            string schema = entityType.GetSchema();
            await ResetIdentityColumn(context, tableName, schema);
        }
    }
    
    /// <summary>
    /// Resets the identity column for a given table.
    /// </summary>
    private static async Task ResetIdentityColumn(
        AdventureWorksDbContext context,
        string tableName,
        string schema
    )
    {
        string fullTableName = string.IsNullOrEmpty(schema)
            ? $"[{tableName}]"
            : $"[{schema}].[{tableName}]";
        // In SQL Server, the behavior of DBCC CHECKIDENT depends on the state of the table:
        // - If the table has never had any rows inserted, DBCC CHECKIDENT will not reset the identity seed.
        // - If the table has had rows inserted and then deleted, DBCC CHECKIDENT will reset the identity seed as expected.
        // The condition was added to the script because the seed was being set to -1 in some cases.
        var sql =
            $@"
            DECLARE @sql NVARCHAR(MAX);
            SET @sql = 'IF EXISTS (SELECT * FROM sys.identity_columns WHERE OBJECT_NAME(OBJECT_ID) = ''{tableName}'' AND last_value IS NOT NULL) 
                        DBCC CHECKIDENT (''{fullTableName}'', RESEED, 0);';
            EXEC sp_executesql @sql;
        ";
        await context.Database.ExecuteSqlRawAsync(sql);
    }
}

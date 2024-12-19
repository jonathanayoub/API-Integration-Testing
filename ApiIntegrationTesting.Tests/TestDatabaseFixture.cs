#region

using ApiIntegrationTesting.Database;
using Microsoft.EntityFrameworkCore;

#endregion

namespace ApiIntegrationTesting.Tests;

/// <summary>
/// Create a new instance of the AdventureWorksDbContext for integration tests and optionally seed the database with test data.
/// </summary>
internal static class TestDatabaseFixture
{
    private const string ConnectionString =
        @"Data Source=127.0.0.1,1433;Initial Catalog=db-kpd-scus-efp-integration;User Id=sa;Password=P@ssw0rd;Column Encryption Setting=enabled;TrustServerCertificate=True";

    public static async Task<AdventureWorksDbContext> CreateContext(
    )
    {
        var context = new AdventureWorksDbContext(
            new DbContextOptionsBuilder<AdventureWorksDbContext>()
                .UseSqlServer(ConnectionString)
                .Options
        );

            //await SeedTestData(context);

        return context;
    }
    //
    // /// <summary>
    // /// Seed the test data for the integration tests.
    // /// This does not include large configuration data sets like Attributes, AttributeFeatures, DataSourceAttributes,
    // /// DisciplineAttributes, TemplateAttributes
    // /// </summary>
    // public static async Task SeedTestData(AdventureWorksDbContext context)
    // {
    //     await SeedSystemData(context);
    //     await SeedNonSystemData(context);
    // }
    //
    // /// <summary>
    // /// Seed system configuration data for test purposes. This will be from the TestSeedData class.
    // /// </summary>
    // private static async Task SeedSystemData(AdventureWorksDbContext context)
    // {
    //     await DatabaseInsertUtility.InsertWithIdentityInsert(
    //         context,
    //         ObjectCloningUtility.ShallowCloneArraySimpleTypes(TestSeedData.AssetTypes)
    //     );
    //     await DatabaseInsertUtility.InsertWithIdentityInsert(
    //         context,
    //         ObjectCloningUtility.ShallowCloneArraySimpleTypes(TestSeedData.DataSources)
    //     );
    //     await DatabaseInsertUtility.InsertWithIdentityInsert(
    //         context,
    //         ObjectCloningUtility.ShallowCloneArraySimpleTypes(TestSeedData.ImportPurposes)
    //     );
    //     await DatabaseInsertUtility.InsertWithIdentityInsert(
    //         context,
    //         ObjectCloningUtility.ShallowCloneArraySimpleTypes(TestSeedData.ImportStatuses)
    //     );
    //     await DatabaseInsertUtility.InsertWithIdentityInsert(
    //         context,
    //         ObjectCloningUtility.ShallowCloneArraySimpleTypes(TestSeedData.ImportTypes)
    //     );
    //     await DatabaseInsertUtility.InsertWithIdentityInsert(
    //         context,
    //         ObjectCloningUtility.ShallowCloneArraySimpleTypes(TestSeedData.ImportVersions)
    //     );
    //     await DatabaseInsertUtility.InsertWithIdentityInsert(
    //         context,
    //         ObjectCloningUtility.ShallowCloneArraySimpleTypes(TestSeedData.IssuanceStatuses)
    //     );
    //     await DatabaseInsertUtility.InsertWithIdentityInsert(
    //         context,
    //         ObjectCloningUtility.ShallowCloneArraySimpleTypes(TestSeedData.SourceTypes)
    //     );
    //     await DatabaseInsertUtility.InsertWithIdentityInsert(
    //         context,
    //         ObjectCloningUtility.ShallowCloneArraySimpleTypes(TestSeedData.Disciplines)
    //     );
    //     // for permissions data, use PROD seed data so that we get workflows etc as they are built
    //     // this will allow the test user to reference them for integration tests
    //     await InsertWithoutIdentityInsert(
    //         context,
    //         ObjectCloningUtility.ShallowCloneArraySimpleTypes(ImportUtilityDbSeedData.Districts)
    //     );
    //     await InsertWithoutIdentityInsert(
    //         context,
    //         ObjectCloningUtility.ShallowCloneArraySimpleTypes(ImportUtilityDbSeedData.SystemUsers)
    //     );
    //     await InsertWithoutIdentityInsert(
    //         context,
    //         ObjectCloningUtility.ShallowCloneArraySimpleTypes(ImportUtilityDbSeedData.SystemRoles)
    //     );
    //     await InsertWithoutIdentityInsert(
    //         context,
    //         ObjectCloningUtility.ShallowCloneArraySimpleTypes(
    //             ImportUtilityDbSeedData.SystemUserRoles
    //         )
    //     );
    //     await InsertWithoutIdentityInsert(
    //         context,
    //         ObjectCloningUtility.ShallowCloneArraySimpleTypes(ImportUtilityDbSeedData.Workflows)
    //     );
    //     await InsertWithoutIdentityInsert(
    //         context,
    //         ObjectCloningUtility.ShallowCloneArraySimpleTypes(
    //             ImportUtilityDbSeedData.WorkflowPermissions
    //         )
    //     );
    //     await InsertWithoutIdentityInsert(
    //         context,
    //         ObjectCloningUtility.ShallowCloneArraySimpleTypes(
    //             ImportUtilityDbSeedData.SystemRoleWorkflows
    //         )
    //     );
    //     await DatabaseInsertUtility.InsertWithIdentityInsert(
    //         context,
    //         ObjectCloningUtility.ShallowCloneArraySimpleTypes(TestSeedData.Projects)
    //     );
    //     await InsertWithoutIdentityInsert(
    //         context,
    //         ObjectCloningUtility.ShallowCloneArraySimpleTypes(
    //             TestSeedData.ProjectDisciplineConfigurations
    //         )
    //     );
    // }
    //
    // /// <summary>
    // /// Seed system configuration data for test purposes. This will be from the TestSeedData class.
    // /// </summary>
    // private static async Task SeedNonSystemData(AdventureWorksDbContext context)
    // {
    //     // todo: add non-system data incrementally as we need it. Use private static fields for the data similar to the TestSeedData region below
    //     // we can move this to a separate class if it starts to get too large (it probably will)
    //
    //     // todo - remove the below line if we ever add implementation here. It's just here to make the compiler happy
    //     await Task.CompletedTask;
    // }
    //
    // /// <summary>
    // /// Insert data into the database without IDENTITY_INSERT turned on for an entity that has no identity column.
    // /// </summary>
    // private static async Task InsertWithoutIdentityInsert<TEntity>(
    //     DbContext context,
    //     IEnumerable<TEntity> entities
    // )
    //     where TEntity : class
    // {
    //     context.Set<TEntity>().AddRange(entities);
    //
    //     await context.SaveChangesAsync();
    // }
    //
    // /// <summary>
    // /// Delete all data in all of the tables in the database. Do this after each test run to ensure a clean slate for the next test run.
    // /// </summary>
    // public static async Task DeleteDatabaseData()
    // {
    //     await using var context = await CreateContext(false, false);
    //     await DeleteAllDataAsync(context);
    //     await ResetIdentityColumns(context);
    // }
    //
    // /// <summary>
    // /// Delete all data in all of the tables in the database, referencing each property in the DbContext explicitly.
    // /// todo: refactor this to use reflection to get all properties in the DbContext and delete them
    // /// </summary>
    // public static async Task DeleteAllDataAsync(AdventureWorksDbContext context)
    // {
    //     context.ProjectDisciplineConfigurations.RemoveRange(
    //         context.ProjectDisciplineConfigurations
    //     );
    //     context.Disciplines.RemoveRange(context.Disciplines);
    //     context.AssetTypes.RemoveRange(context.AssetTypes);
    //     context.DataSources.RemoveRange(context.DataSources);
    //     context.ImportJobs.RemoveRange(context.ImportJobs);
    //     context.ImportJobExecutions.RemoveRange(context.ImportJobExecutions);
    //     context.ImportPurposes.RemoveRange(context.ImportPurposes);
    //     context.ImportStatus.RemoveRange(context.ImportStatus);
    //     context.ImportTypes.RemoveRange(context.ImportTypes);
    //     context.ImportVersions.RemoveRange(context.ImportVersions);
    //     context.IssuanceStatus.RemoveRange(context.IssuanceStatus);
    //     context.ProjectDataSourceConfigurations.RemoveRange(
    //         context.ProjectDataSourceConfigurations
    //     );
    //     context.Projects.RemoveRange(context.Projects);
    //     context.SourceTypes.RemoveRange(context.SourceTypes);
    //     context.ProjectDataSourceConfigurations.RemoveRange(
    //         context.ProjectDataSourceConfigurations
    //     );
    //     context.Roles.RemoveRange(context.Roles);
    //     context.Users.RemoveRange(context.Users);
    //     context.Workflows.RemoveRange(context.Workflows);
    //     context.UserRoles.RemoveRange(context.UserRoles);
    //     context.RoleWorkflows.RemoveRange(context.RoleWorkflows);
    //     context.WorkflowPermissions.RemoveRange(context.WorkflowPermissions);
    //     context.Districts.RemoveRange(context.Districts);
    //
    //     await context.SaveChangesAsync();
    // }
    //
    // /// <summary>
    // /// Set the identity columns back to 0 for all tables that have an identity column.
    // /// This is needed to reset the identity columns after deleting all data.
    // /// </summary>
    // private static async Task ResetIdentityColumns(AdventureWorksDbContext context)
    // {
    //     var entityTypes = context.Model.GetEntityTypes();
    //     var tablesWithIdentity = entityTypes
    //         .Where(e =>
    //             e.FindPrimaryKey()?.Properties.Any(p => p.ValueGenerated == ValueGenerated.OnAdd)
    //             == true
    //         )
    //         .ToList();
    //
    //     foreach (var entityType in tablesWithIdentity)
    //     {
    //         var tableName = entityType.GetTableName();
    //         var schema = entityType.GetSchema();
    //         await ResetIdentityColumn(context, tableName, schema);
    //     }
    // }
    //
    // /// <summary>
    // /// Resets the identity column for a given table.
    // /// </summary>
    // public static async Task ResetIdentityColumn(
    //     AdventureWorksDbContext context,
    //     string tableName,
    //     string schema
    // )
    // {
    //     var fullTableName = string.IsNullOrEmpty(schema)
    //         ? $"[{tableName}]"
    //         : $"[{schema}].[{tableName}]";
    //     // In SQL Server, the behavior of DBCC CHECKIDENT depends on the state of the table:
    //     // - If the table has never had any rows inserted, DBCC CHECKIDENT will not reset the identity seed.
    //     // - If the table has had rows inserted and then deleted, DBCC CHECKIDENT will reset the identity seed as expected.
    //     // The condition was added to the script because the seed was being set to -1 in some cases.
    //     var sql =
    //         $@"
    //         DECLARE @sql NVARCHAR(MAX);
    //         SET @sql = 'IF EXISTS (SELECT * FROM sys.identity_columns WHERE OBJECT_NAME(OBJECT_ID) = ''{tableName}'' AND last_value IS NOT NULL) 
    //                     DBCC CHECKIDENT (''{fullTableName}'', RESEED, 0);';
    //         EXEC sp_executesql @sql;
    //     ";
    //     await context.Database.ExecuteSqlRawAsync(sql);
    // }
}

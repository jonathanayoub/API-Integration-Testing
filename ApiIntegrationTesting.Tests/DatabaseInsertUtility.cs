#region

using Microsoft.EntityFrameworkCore;

#endregion

namespace ApiIntegrationTesting.Tests;

/// <summary>
/// Utility class with methods for inserting data into the database.
/// </summary>
internal static class DatabaseInsertUtility
{
    /// <summary>
    /// Insert data into the database with IDENTITY_INSERT turned on.
    /// </summary>
    public static async Task InsertWithIdentityInsert<TEntity>(
        DbContext context,
        IEnumerable<TEntity> entities
    )
        where TEntity : class
    {
        // Get the entity type from the DbContext
        var entityType = context.Model.FindEntityType(typeof(TEntity));
        if (entityType == null)
        {
            throw new InvalidOperationException(
                $"Entity type {typeof(TEntity).Name} not found in DbContext."
            );
        }

        // Get the table name from the entity type
        var tableName = entityType.GetTableName();
        var schema = entityType.GetSchema();
        if (string.IsNullOrEmpty(tableName))
        {
            throw new InvalidOperationException(
                $"Table name for entity type {typeof(TEntity).Name} not found."
            );
        }

        // Set IDENTITY_INSERT ON for the table, then insert the data, then set it back to OFF
        await using var transaction = await context.Database.BeginTransactionAsync();

        // Suppress EF Core warning for setting IDENTITY_INSERT. This code does not come from user input. No risk of SQL injection.
#pragma warning disable EF1002
        await context.Database.ExecuteSqlRawAsync($"SET IDENTITY_INSERT {schema}.{tableName} ON");

        context.Set<TEntity>().AddRange(entities);

        await context.SaveChangesAsync();

        await context.Database.ExecuteSqlRawAsync($"SET IDENTITY_INSERT {schema}.{tableName} OFF");
#pragma warning restore EF1002

        await transaction.CommitAsync();
    }
}

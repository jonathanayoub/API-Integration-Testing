using ApiIntegrationTesting.Database;

namespace ApiIntegrationTesting.Tests;

/// <summary>
/// Setup the Docker container for SQL Server and create the database for the entire test run.
/// </summary>
[TestClass]
public class TestRunInitialize
{
    private static SqlServerFixture _sqlServerFixture = null!;

    [AssemblyInitialize]
    public static async Task AssemblyInitialize(TestContext testContext)
    {
        // Start SQL Server to be used for the entire test run
        _sqlServerFixture = new SqlServerFixture();
        _sqlServerFixture.CreateServer();

        // Create the database
        AdventureWorksDbContext context = await TestDatabaseFixture.CreateContext();
        await context.Database.EnsureCreatedAsync();
    }

    [AssemblyCleanup]
    public static void AssemblyCleanup()
    {
        _sqlServerFixture?.Dispose();
    }
}

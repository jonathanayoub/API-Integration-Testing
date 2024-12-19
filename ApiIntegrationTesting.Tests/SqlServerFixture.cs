using Ductus.FluentDocker.Builders;
using Ductus.FluentDocker.Services;
using Ductus.FluentDocker.Services.Extensions;

namespace ApiIntegrationTesting.Tests;

internal class SqlServerFixture : IDisposable
{
    private static IContainerService _container;

    public void CreateServer()
    {
        var hosts = new Hosts().Discover();
        var docker =
            hosts.FirstOrDefault(x => x.IsNative) ?? hosts.FirstOrDefault(x => x.Name == "default");

        if (docker == null)
            throw new InvalidOperationException(
                "Docker daemon running locally is required to create server. Make sure that it is installed on your machine."
            );

        const string sqlServerUbuntuImage = "mcr.microsoft.com/mssql/server:latest";
        const string sqlServerIsRunningLog = "Recovery is complete."; // This is the last log message before the server is ready to accept connections.
        _container = new Builder()
            .UseContainer()
            .UseImage(sqlServerUbuntuImage)
            .ExposePort(1433, 1433)
            .WithEnvironment("SA_PASSWORD=P@ssw0rd", "ACCEPT_EULA=Y", "MSSQL_PID=Developer")
            .Build()
            .Start()
            .WaitForMessageInLogs(
                sqlServerIsRunningLog,
                300000 /*5 min*/
            );
    }

    public void Dispose()
    {
        _container?.Dispose();
    }
}

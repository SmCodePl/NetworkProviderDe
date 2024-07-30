using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using NetworkProviderDe.Domain;
using NetworkProviderDe.Infrastructure;
using NetworkProviderDe.Infrastructure.NetworkProviderDe.Domain.CompiledModels;

namespace NetworkProviderDe.Api.DesignTime;

public class NetProviderContextFactory : IDesignTimeDbContextFactory<NetProviderContext>
{
    private string AdminConnectionString => "NET_PROVIDER_ADMIN_CONNECTION_STRING";
    public NetProviderContext CreateDbContext(string[] args)
    {
        
        var connectionString = Environment.GetEnvironmentVariable(AdminConnectionString);
        
        if (string.IsNullOrWhiteSpace(connectionString))
        {
            throw new ArgumentException("Connection string is required", nameof(connectionString));
        }

        var optionsBuilder = new DbContextOptionsBuilder<NetProviderContext>()
            .UseSqlServer(connectionString,sqlOptions =>
            {
                sqlOptions.MigrationsAssembly(
                    typeof(ServiceRegistation).Assembly.FullName);
                 sqlOptions.UseNetTopologySuite();
            });

        return new NetProviderContext(optionsBuilder.Options, new DesignTimeModelConfiguration());
    }
}

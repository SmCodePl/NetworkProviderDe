
using Microsoft.Extensions.DependencyInjection;
using NetworkProviderDe.Domain;
using NetworkProviderDe.Infrastructure.Configuration;
using NetworkProviderDe.SharedKernel.Configuration;
using Microsoft.EntityFrameworkCore;


namespace NetworkProviderDe.Infrastructure;
/// <summary>
/// Infrastructure service registartion 
/// Requires connection string and isDevelopment flag
/// SqlServer is used as the database provider
/// Uses NetTopologySuite for spatial data
/// </summary>
public static class ServiceRegistation
{
    public static IServiceCollection AddInfrastructure(
        this IServiceCollection services, 
        string connectionString, 
        bool isDevelopment
    )
    {
      
        if (string.IsNullOrWhiteSpace(connectionString))
        {
            throw new ArgumentException("Connection string is required", nameof(connectionString));
        }

        services.AddSingleton<IModelConfiguration, SqlModelConfiguration>();
        services.AddDbContext<NetProviderContext>(options =>
        {
            options.UseSqlServer(connectionString, sqlOptions =>
            {
                sqlOptions.MigrationsAssembly(typeof(ServiceRegistation).Assembly.FullName);
                sqlOptions.UseNetTopologySuite();
            });
            if (isDevelopment)
            {
                options.EnableSensitiveDataLogging();
            }
        });
        services.AddDomainServices();

        return services;
    }
}

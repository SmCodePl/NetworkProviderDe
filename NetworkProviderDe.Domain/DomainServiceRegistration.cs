using Microsoft.Extensions.DependencyInjection;
using NetworkProviderDe.Domain.Services;

namespace NetworkProviderDe.Domain;

public static class DomainServiceRegistration
{
    /// <summary>
    ///  Domain Service Registration
    ///  Addes Domain Services to the Service Collection
    ///  services.AddScoped<FiberNetService>()
    /// </summary>
    /// <param name="services"></param>
    /// <returns></returns>
    public static IServiceCollection AddDomainServices(this IServiceCollection services)
    {
        services.AddMemoryCache();
        services.AddScoped<FiberNetService>();
        return services;
    }
}

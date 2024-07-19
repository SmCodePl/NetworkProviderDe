using Microsoft.EntityFrameworkCore;
using NetworkProviderDe.SharedKernel.Configuration;


namespace NetworkProviderDe.Infrastructure.Configuration;

internal class SqlModelConfiguration : IModelConfiguration
{
    public void ConfigureModel(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(SqlModelConfiguration).Assembly);
    }
}

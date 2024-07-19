using Microsoft.EntityFrameworkCore;
using NetworkProviderDe.SharedKernel.Configuration;

namespace NetworkProviderDe.Domain
{
    public class NetProviderContext : DbContext
    {
        private readonly IModelConfiguration _modelConfiguration;

        public NetProviderContext(
            DbContextOptions<NetProviderContext> options,
            IModelConfiguration modelConfiguration
        ) : base(options)
        {
            _modelConfiguration = modelConfiguration;
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(NetProviderContext).Assembly);
            _modelConfiguration.ConfigureModel(modelBuilder);
        }
    }
}

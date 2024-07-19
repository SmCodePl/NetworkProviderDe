
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NetworkProviderDe.Domain.Entities;

namespace NetworkProviderDe.Domain.Configuration;

internal class NetAreaFiberPlanConfiguration : IEntityTypeConfiguration<NetAreaFiberPlan>
{
    public void Configure(EntityTypeBuilder<NetAreaFiberPlan> builder)
    {
        builder
            .HasKey(p => p.AreaFiberPlanId);
        
    }
}

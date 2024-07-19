

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NetworkProviderDe.Domain.Entities;

namespace NetworkProviderDe.Domain.Configuration;

public class FiberNetPlanConfiguration : IEntityTypeConfiguration<FiberNetPlan>
{
    public void Configure(EntityTypeBuilder<FiberNetPlan> builder)
    {
        builder
            .HasKey(p => p.PlanId);
        builder
            .Property(p => p.ProviderName)
            .HasMaxLength(255);
        builder
            .Property(p => p.PlanName)
            .HasMaxLength(255);
        builder
            .Property(p => p.PlanDescription)
            .HasMaxLength(1000);
    }
}

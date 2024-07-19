
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NetworkProviderDe.Domain.Entities;

namespace NetworkProviderDe.Domain.Configuration;

public class NetAreaConfiguration : IEntityTypeConfiguration<NetArea>
{
    public void Configure(EntityTypeBuilder<NetArea> builder)
    {
        builder
            .HasKey(p => p.AreaId);
            
        builder
            .Property(p => p.CountryCode)
            .HasMaxLength(2);
        builder
            .Property(p => p.PostalCode)
            .HasMaxLength(5);
        builder
            .Property(p => p.PlaceName)
            .HasMaxLength(255);
        builder
            .Property(p => p.AdminName)
            .HasMaxLength(500);
        builder
            .Property(p => p.AdminCode)
            .HasMaxLength(2);
    }
}

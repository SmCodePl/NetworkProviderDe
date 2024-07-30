
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NetworkProviderDe.Domain.Entities;

namespace NetworkProviderDe.Domain.Configuration;

internal class ProductAreaConfiguration : IEntityTypeConfiguration<ProductArea>
{
    public void Configure(EntityTypeBuilder<ProductArea> builder)
    {
        builder
            .HasKey(p => p.ProductAreaId);
        
    }
}

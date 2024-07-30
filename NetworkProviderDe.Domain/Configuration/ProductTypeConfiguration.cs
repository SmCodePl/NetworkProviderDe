using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NetworkProviderDe.Domain.Entities;

namespace NetworkProviderDe.Domain.Configuration;

public class ProductTypeConfiguration : IEntityTypeConfiguration<ProductType>
{
    public void Configure(EntityTypeBuilder<ProductType> builder)
    {
        builder
            .HasKey(p => p.ProductTypeId);
        builder
            .Property(p => p.ProductTypeName)
            .HasMaxLength(255);
    }
}

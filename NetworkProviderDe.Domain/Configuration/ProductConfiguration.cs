

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NetworkProviderDe.Domain.Entities;

namespace NetworkProviderDe.Domain.Configuration;

public class ProductConfiguration : IEntityTypeConfiguration<Product>
{
    public void Configure(EntityTypeBuilder<Product> builder)
    {
        builder
            .HasKey(p => p.ProductId);
        builder
            .Property(p => p.ProductName)
            .HasMaxLength(255);
        builder
            .Property(p => p.ProductDescription)
            .HasMaxLength(1000);
    }
}

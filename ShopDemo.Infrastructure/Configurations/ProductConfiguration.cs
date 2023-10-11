using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ShopDemo.Domain;

namespace ShopDemo.Infrastructure.Configurations;

public class ProductConfiguration : IEntityTypeConfiguration<Product>
{
    public void Configure(EntityTypeBuilder<Product> builder)
    {
        builder.HasData(
            new Product
            {
                Id = 1,
                Name = "Morshyn water",
                Description = "Morshyn water is a natural mineral water known for its therapeutic properties.",
                Price = 18.90,
                Quantity = 1,
                DateCreated = DateTime.Now
            }
        );

        builder.Property(u => u.Name)
            .IsRequired()
            .HasMaxLength(100);
    }
}
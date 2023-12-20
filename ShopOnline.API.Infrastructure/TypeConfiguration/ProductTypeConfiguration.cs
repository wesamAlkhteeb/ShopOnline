
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ShopOnline.API.Domain.Entities;

namespace ShopOnline.API.Infrastructure.TypeConfiguration
{
    public class ProductTypeConfiguration : IEntityTypeConfiguration<ProductEntity>
    {
        public void Configure(EntityTypeBuilder<ProductEntity> builder)
        {
            builder.HasMany<OrderProductEntity>()
                .WithOne()
                .HasForeignKey(product => product.ProductId);
            builder.Property(product => product.price).HasPrecision(18, 2);
        }
    }
}

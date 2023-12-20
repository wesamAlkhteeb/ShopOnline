using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ShopOnline.API.Domain.Entities;

namespace ShopOnline.API.Infrastructure.TypeConfiguration
{
    public class OrderTypeConfiguration : IEntityTypeConfiguration<OrderEntity>
    {
        public void Configure(EntityTypeBuilder<OrderEntity> builder)
        {
            builder.HasMany<OrderProductEntity>()
                .WithOne()
                .HasForeignKey(p => p.OrderId);
            builder.Property(order=>order.totalPrice).HasPrecision(18,2);
        }
    }
}

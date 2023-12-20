using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ShopOnline.API.Domain.Entities;


namespace ShopOnline.API.Infrastructure.TypeConfiguration
{
    public class CategoryTypeConfiguration : IEntityTypeConfiguration<CategoryEntity>
    {
        public void Configure(EntityTypeBuilder<CategoryEntity> builder)
        {
            builder.HasMany<ProductEntity>()
                .WithOne()
                .HasForeignKey(product => product.CategoryId);
        }
    }
}

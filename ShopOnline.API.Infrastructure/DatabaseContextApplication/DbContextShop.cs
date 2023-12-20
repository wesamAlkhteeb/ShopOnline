using Microsoft.EntityFrameworkCore;
using ShopOnline.API.Domain.Entities;
using ShopOnline.API.Infrastructure.TypeConfiguration;

namespace ShopOnline.API.Infrastructure.DatabaseContextApplication
{
    public class DbContextShop:DbContext
    {
        
        public DbSet<AccountEntity> Accounts { get; set; }
        public DbSet<ProductEntity> Products{ get; set; }
        public DbSet<OrderProductEntity> OrderProductEntities{ get; set; }
        public DbSet<OrderEntity> Orders{ get; set; }
        public DbSet<CategoryEntity> Categories{ get; set; }

        public DbContextShop(DbContextOptions<DbContextShop>options):base(options){}

        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new AccountTypeConfiguration());
            modelBuilder.ApplyConfiguration(new CategoryTypeConfiguration());
            modelBuilder.ApplyConfiguration(new OrderTypeConfiguration());
            modelBuilder.ApplyConfiguration(new ProductTypeConfiguration());

        }
    }
}

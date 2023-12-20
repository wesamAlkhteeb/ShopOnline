using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ShopOnline.API.Domain.Entities;
using ShopOnline.API.Domain.Helper;
using ShopOnline.API.Domain.Helper.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopOnline.API.Infrastructure.TypeConfiguration
{
    public class AccountTypeConfiguration : IEntityTypeConfiguration<AccountEntity>
    {
        public void Configure(EntityTypeBuilder<AccountEntity> builder)
        {
            builder.HasMany<OrderEntity>()
                    .WithOne()
                    .HasForeignKey(s => s.AccountId);
            
            seedData(builder);

        }

        public void seedData(EntityTypeBuilder<AccountEntity> builder)
        {
            builder.HasData(new AccountEntity
            {
                Id=1,
                Email = "admin@gmail.com",
                Password = JwtSecurity.securityData.getHashPassword("Wesam@204"),
                Role = Roles.admin.ToString(),
                UserName = "admin"
            });
        }
    }
}

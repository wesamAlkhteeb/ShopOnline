using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ShopOnline.API.Application.Repositories;
using ShopOnline.API.Application.Services;
using ShopOnline.API.Application.Services.interfaces;
using ShopOnline.API.Domain.Repositories;
using ShopOnline.API.Infrastructure.DatabaseContextApplication;
using ShopOnline.API.Infrastructure.Repositories;

namespace ShopOnline.API.Infrastructure.DependencyInjectionInfrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection DIRepository(this IServiceCollection services)
        {
            services.AddScoped<IAccountRepository, AccountRepository>();
            services.AddScoped<ICategoryRepository, CategoryRepository>();
            services.AddScoped<IProductRepository, ProductRepository>();
            return services;
        }

        public static IServiceCollection DIDatabase(this IServiceCollection services,IConfiguration configuration)
        {
            services.AddDbContext<DbContextShop>(option=>
            {

                string cs = configuration.GetConnectionString("default")!;
                option.UseSqlServer(cs);
            });
            return services;
        }
    }
}

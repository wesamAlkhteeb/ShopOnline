

using Microsoft.Extensions.DependencyInjection;
using ShopOnline.API.Application.Repositories;
using ShopOnline.API.Application.Services;
using ShopOnline.API.Application.Services.interfaces;

namespace ShopOnline.API.Application.DependencyInjectionApplication
{
    public static class DIApp
    {
        public static IServiceCollection DIService(this IServiceCollection services) 
        {
            services.AddScoped<IAccountService,AccountService>();
            services.AddScoped<IProductService,ProductService>();
            services.AddScoped<ICategoryService,CategoryService>();

            return services;
        }
    }
}

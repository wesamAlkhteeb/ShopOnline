using ShopOnline.API.Infrastructure.DatabaseContextApplication;

namespace ShopOnline.API.Middleware
{
    public class CheckDatabaseMiddleware
    {
        private readonly RequestDelegate next;
        private readonly IServiceProvider service;

        public CheckDatabaseMiddleware(RequestDelegate next , IServiceProvider service)
        {
            this.next = next;
            this.service = service;
        }
        public async Task InvokeAsync(HttpContext context)
        {
            using (var scope = service.CreateScope()) {
                DbContextShop db = scope.ServiceProvider.GetRequiredService<DbContextShop>();
                await db.Database.EnsureCreatedAsync();
            }
            
            await next(context);

        }
    }
}

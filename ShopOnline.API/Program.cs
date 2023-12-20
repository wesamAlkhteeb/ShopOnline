using HealthChecks.UI.Client;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using Microsoft.EntityFrameworkCore;
using ShopOnline.API.ActionFilters;
using ShopOnline.API.Application.DependencyInjectionApplication;
using ShopOnline.API.Domain.DependencyInjectionDomain;
using ShopOnline.API.Infrastructure.DatabaseContextApplication;
using ShopOnline.API.Infrastructure.DependencyInjectionInfrastructure;
using ShopOnline.API.Middleware;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers(options =>
{
    options.Filters.Add<ValidationActionFilter>();
});
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.DISecurity(builder.Configuration);
builder.Services.DIDatabase(builder.Configuration);
builder.Services.DIRepository();
builder.Services.DIService();


builder.Services.AddHealthChecks();

var a = builder.Configuration.GetConnectionString("Default");

var app = builder.Build();

app.UseMiddleware<CheckDatabaseMiddleware>();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();
app.UseStaticFiles();
app.MapControllers();


app.MapHealthChecks("health", new HealthCheckOptions
{
    ResponseWriter = UIResponseWriter.WriteHealthCheckUIResponse,
});

app.UseMiddleware<ErrorHandlingMiddleware>();

app.Run();

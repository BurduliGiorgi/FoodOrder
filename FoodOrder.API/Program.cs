using FoodOrder.API.Endpoints;
using FoodOrder.Infrastructure;
using FoodOrder.Infrastructure.Seeders;
using Scalar.AspNetCore;
using FoodOrder.Application;
var builder = WebApplication.CreateBuilder(args);

builder.AddInfrastructureServices();
builder.AddApplicationServices();
builder.Services.AddEndpoints(typeof(Program).Assembly);
builder.Services.AddControllers();
builder.Services.AddOpenApi();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.MapScalarApiReference();
}

app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();
app.MapEndpoints();
await DbSeeder.SeedAsync(app.Services);

app.Run();
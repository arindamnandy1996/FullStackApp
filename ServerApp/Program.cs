using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);

// Copilot suggested enabling CORS globally to support cross-origin calls from Blazor
builder.Services.AddCors();

var app = builder.Build();

app.UseCors(policy => policy.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());

// Copilot recommended using strongly typed records for better serialization and maintainability
app.MapGet(
    "/api/productlist",
    () =>
    {
        return new[]
        {
            new Product(1, "Laptop", 1200.50, 25, new Category(101, "Electronics")),
            new Product(2, "Headphones", 50.00, 100, new Category(102, "Accessories")),
        };
    }
);

app.Run();

// Models
public record Category(int Id, string Name);

public record Product(int Id, string Name, double Price, int Stock, Category Category);

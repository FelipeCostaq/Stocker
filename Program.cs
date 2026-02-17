using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using Stocker.Data;
using Stocker.Models;
using Stocker.Services;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<AppDbContext>();
builder.Services.AddScoped<ProductService>();

var app = builder.Build();

app.MapGet("/products", async (ProductService service) => Results.Ok(await service.ListProduct()));

app.MapGet("/products/{id:guid}", async (Guid id, ProductService service) =>
{
    var foundProduct = await service.GetProductById(id);

    return foundProduct is not null ? Results.Ok(foundProduct) : Results.NotFound();
});

app.MapPost("/products", async (Product product, ProductService service) =>
{
    var newProduct = await service.CreateProduct(product);

    return Results.Created($"/products/{newProduct.Id}", newProduct);
});

app.MapDelete("/products/{id:guid}", async (Guid id, ProductService service) =>
{
    var foundProduct = await service.DeleteProduct(id);
    return Results.Ok(foundProduct);
});

app.MapPut("/products/{id:guid}", async (Guid id, Product product,ProductService service) =>
{
    var foundProduct = await service.UpdateProduct(id, product);

    if (foundProduct is null)
        return Results.NotFound(new { Message = "Produto não encontrado" } );

    return Results.Ok(foundProduct);
});

app.Run();

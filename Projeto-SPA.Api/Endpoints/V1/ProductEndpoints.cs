using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using Projeto_SPA.Api.ApiHelpers;
using Projeto_SPA.Api.Contracts.V1.Categories;
using Projeto_SPA.Api.Contracts.V1.Products;
using Projeto_SPA.Api.Data;
using Projeto_SPA.Api.Models;
using Projeto_SPA.Api.Responses;

namespace Projeto_SPA.Api.Endpoints.V1
{
    public static class ProductEndpoints
    {
        public static void MapProductEndpoints(this WebApplication app)
        {
            var map = app.MapGroup("/api/v1/products");

            map.MapGet("", async (AppDbContext db) =>
            {
                var result = await db.Products
                    .AsNoTracking()
                    .Select(c => new ProductResponse
                    {
                        Id = c.Id,
                        Title = c.Title,
                        Price = c.Price,
                        CategoryId = c.CategoryId
                    })
                    .ToListAsync();

                return Results.Ok(
                    new ApiResponse<IEnumerable<ProductResponse>>(
                        result,
                        "Products retrieved successfully"
                    ));
            });

            map.MapGet("/{id:int}", async (int id, AppDbContext db) =>
            {
                var result = await db.Products
                    .AsNoTracking()
                    .Where(p => p.Id == id)
                    .Select(p => new ProductResponse
                    {
                        Id = p.Id,
                        Title = p.Title,
                        Price = p.Price,
                        CategoryId = p.CategoryId
                    })
                    .FirstOrDefaultAsync();

                if (result == null)
                    return Results.NotFound(
                        new ApiResponse<object>(
                            new[] { "Product not found" },
                            "Resource not found"
                        ));

                return Results.Ok(
                    new ApiResponse<ProductResponse>(
                        result,
                        "Product retrieved successfully"
                    ));
            });

            map.MapPost("", async (CreateProductRequest request, AppDbContext db) =>
            {
                var errors = ValidationHelper.ValidateModel(request);
                if (errors.Any())
                    return Results.BadRequest(
                        new ApiResponse<object>(
                            errors,
                            "Validation failed"
                        ));

                var categoryExists = await db.Categories
                    .AnyAsync(c => c.Id == request.CategoryId);
                if(!categoryExists)
                    return Results.BadRequest(
                        new ApiResponse<object>(
                            new[] { "Category does not exist" },
                            "Validation failed"
                        ));

                var product = new Product
                {
                    Title = request.Title,
                    Price = request.Price,
                    CategoryId = request.CategoryId
                };

                db.Products.Add(product);
                await db.SaveChangesAsync();

                var response = new ProductResponse
                {
                    Id = product.Id,
                    Title = product.Title,
                    Price = product.Price,
                    CategoryId = product.CategoryId
                };

                return Results.Created($"/api/v1/products/{response.Id}",
                    new ApiResponse<ProductResponse>(
                        response,
                        "Product created successfully"
                    ));
            });

            map.MapPut("/{id:int}", async (int id, UpdateProductRequest request, AppDbContext db) =>
            {
                var errors = ValidationHelper.ValidateModel(request);
                if (errors.Any())
                    return Results.BadRequest(
                        new ApiResponse<object>(
                            errors,
                            "Validation failed"
                        ));

                var categoryExists = await db.Categories
                    .AnyAsync(c => c.Id == request.CategoryId);
                if (!categoryExists)
                    return Results.BadRequest(
                        new ApiResponse<object>(
                            new[] { "Category does not exist" },
                            "Validation failed"
                        ));

                var product = await db.Products.FindAsync(id);
                if (product == null)
                    return Results.NotFound(
                        new ApiResponse<object>(
                            new[] { "Product not found" },
                            "Resource not found"
                        ));

                product.Title = request.Title;
                product.Price = request.Price;
                product.CategoryId = request.CategoryId;

                await db.SaveChangesAsync();

                var response = new ProductResponse
                {
                    Id = product.Id,
                    Title = product.Title,
                    Price = product.Price,
                    CategoryId = product.CategoryId
                };

                return Results.Ok(
                    new ApiResponse<ProductResponse>(
                        response,
                        "Product updated successfully"
                    ));
            });

            map.MapDelete("/{id:int}", async (int id, AppDbContext db) =>
            {
                var product = await db.Products.FindAsync(id);
                if (product == null)
                    return Results.NotFound(
                        new ApiResponse<object>(
                            new[] { "Product not found" },
                            "Resource not found"
                    ));

                db.Products.Remove(product);
                await db.SaveChangesAsync();

                return Results.NoContent();
            });
        }
    }
}

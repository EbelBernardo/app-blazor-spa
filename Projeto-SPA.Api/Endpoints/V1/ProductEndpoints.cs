using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using Projeto_SPA.Api.Contracts.V1.Products;
using Projeto_SPA.Api.Data;
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
                    new ApiResponse<List<ProductResponse>>(
                        result,
                        "Products retrivered successfully"
                    ));
            });

            map.MapGet("/{id}", async (int id, AppDbContext db) =>
            {
                var result = await db.Products
                    .AsNoTracking()
                    .Where(c => c.Id == id)
                    .Select(c => new ProductResponse
                    {
                        Id = c.Id,
                        Title = c.Title,
                        Price = c.Price,
                        CategoryId = c.CategoryId
                    })
                    .FirstOrDefaultAsync();

                if (result == null)
                    return Results.NotFound(
                        new ApiResponse<object>(
                            new[] {"Product not found"},
                            "Resource not found"
                        ));

                return Results.Ok(
                    new ApiResponse<ProductResponse>(
                        result,
                        "Product retriverect successfully"
                    ));
            });
        }
    }
}

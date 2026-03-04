using Microsoft.EntityFrameworkCore;
using Projeto_SPA.Api.Contracts.V1.Categories;
using Projeto_SPA.Api.Data;

namespace Projeto_SPA.Api.Endpoints.V1
{
    public static class CategoryEndpoints
    {
        public static void MapCategoryEndpoints(this WebApplication app)
        {
            var map = app.MapGroup("/api/v1/categories");

            map.MapGet("", async (AppDbContext db) =>
            {
                var result = await db.Categories
                .AsNoTracking()
                .Select(c => new CategoryResponse
                { 
                    Id = c.Id,
                    Title = c.Title
                })
                .ToListAsync();

                return Results.Ok(result);
            });

            map.MapGet("/{id:int}", async (int id, AppDbContext db) =>
            {
                var result = await db.Categories
                    .AsNoTracking()
                    .Where(c => c.Id == id)
                    .Select(c => new CategoryResponse
                    { 
                        Id = c.Id,
                        Title = c.Title
                    })
                    .FirstOrDefaultAsync();

                if (result == null)
                    return Results.NotFound();

                return Results.Ok(result);
            });
        }
    }
}

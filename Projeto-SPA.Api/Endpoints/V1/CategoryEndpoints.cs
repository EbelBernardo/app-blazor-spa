using Microsoft.EntityFrameworkCore;
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
                var result = await db.Categories.ToListAsync();
                return Results.Ok(result);
            });

            map.MapGet("/{id}", async (int id, AppDbContext db) =>
            {
                var result = await db.Categories.FindAsync(id);
                if(result == null) 
                    return Results.NotFound();

                return Results.Ok(result);
            });
        }
    }
}

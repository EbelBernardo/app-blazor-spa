using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using Projeto_SPA.Api.Data;

namespace Projeto_SPA.Api.Endpoints.V1
{
    public static class ProductEndpoints
    {
        public static void MapProductEndpoints(this WebApplication app)
        {
            var map = app.MapGroup("api/v1/products");

            map.MapGet("", async (AppDbContext db) => 
            { 
                var result = await db.Products.ToListAsync();
                return Results.Ok(result);
            });

            map.MapGet("/{id}", async (int id, AppDbContext db) =>
            {
                var result = await db.Products.FindAsync(id);
                if (result == null)
                    return Results.NotFound();

                return Results.Ok(result);
            });
        }
    }
}

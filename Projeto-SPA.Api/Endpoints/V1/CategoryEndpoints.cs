using Microsoft.EntityFrameworkCore;
using Projeto_SPA.Api.ApiHelpers;
using Projeto_SPA.Api.Contracts.V1.Categories;
using Projeto_SPA.Api.Data;
using Projeto_SPA.Api.Models;
using Projeto_SPA.Api.Responses;

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

                return Results.Ok(
                    new ApiResponse<IEnumerable<CategoryResponse>>(
                        result,
                        "Categories retrieved successfully"
                    ));
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
                    return Results.NotFound(
                        new ApiResponse<object>(
                            new[] {"Category not found"},
                            "Resource not found"
                        ));

                return Results.Ok(
                    new ApiResponse<CategoryResponse>(
                        result,
                        "Category retrieved successfully"
                    ));
            });

            map.MapPost("", async(CreateCategoryRequest request, AppDbContext db) =>
            {
                var errors = ValidationHelper.ValidateModel(request);
                if(errors.Any())
                    return Results.BadRequest(
                        new ApiResponse<object>(
                            errors,
                            "Validation failed"
                    ));

                var category = new Category
                {
                    Title = request.Title
                };

                db.Categories.Add(category);
                await db.SaveChangesAsync();

                var response = new CategoryResponse
                {
                    Id = category.Id,
                    Title = category.Title
                };

                return Results.Created($"/api/v1/categories/{category.Id}",
                    new ApiResponse<CategoryResponse>(
                        response,
                        "Category created successfully"
                    ));
            });

            map.MapPut("/{id:int}", async (int id, UpdateCategoryRequest request, AppDbContext db) =>
            {
                var errors = ValidationHelper.ValidateModel(request);
                if (errors.Any())
                    return Results.BadRequest(
                        new ApiResponse<object>(
                            errors,
                            "Validation failed"
                        ));

                var category = await db.Categories.FindAsync(id);
                if (category == null)
                    return Results.NotFound(
                        new ApiResponse<object>(
                            new[] {"Category not found"},
                            "Resource not found"
                        ));

                category.Title = request.Title;

                await db.SaveChangesAsync();

                var response = new CategoryResponse
                {
                    Id = category.Id,
                    Title = category.Title
                };

                return Results.Ok(
                    new ApiResponse<CategoryResponse>(
                        response,
                        "Category updated successfully"
                    ));
            });

            map.MapDelete("/{id:int}", async (int id, AppDbContext db) =>
            {
                var category = await db.Categories.FindAsync(id);
                if(category == null)
                    return Results.NotFound(
                        new ApiResponse<object>(
                            new[] {"Category not found"},
                            "Resource not found"
                        ));

                db.Categories.Remove(category);
                await db.SaveChangesAsync();

                return Results.NoContent();
            });
        }
    }
}

namespace Projeto_SPA.Api.Endpoints.V1
{
    public static class CategoryEndpoints
    {
        public static void MapCategoryEndpoints(this WebApplication app)
        {
            var map = app.MapGroup("/api/v1/categories");

            map.MapGet("", () => Results.Ok(new[] { "Category 1", "Category 2" }))
                .WithTags("Categories")
                .WithSummary("Returns all test categories")
                .WithDescription("This endpoints returns dummy categories only for Swagger test");
        }
    }
}

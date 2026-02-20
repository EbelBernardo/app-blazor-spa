namespace Projeto_SPA.Api.Endpoints.V1
{
    public static class ProductEndpoints
    {
        public static void MapProductEndpoints(this WebApplication app)
        {
            var map = app.MapGroup("api/v1/products");

            map.MapGet("", () => Results.Ok(new[] { "Product 1", "Product 2" }))
                .WithTags("Products")
                .WithSummary("Returns all test products")
                .WithDescription("This endpoints returns dummy products only for Swagger test");
        }
    }
}

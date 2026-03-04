namespace Projeto_SPA.Api.Contracts.V1.Products
{
    public class UpdateProductRequest
    {
        public required string Title { get; set; }

        public decimal Price { get; set; }

        public int CategoryId { get; set; }
    }
}

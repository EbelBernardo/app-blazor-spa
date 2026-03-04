namespace Projeto_SPA.Api.Contracts.V1.Products
{
    public class ProductResponse
    {
        public int Id { get; set; }

        public string Title { get; set; } = null!;

        public decimal Price { get; set; }

        public int CategoryId { get; set; }
    }
}

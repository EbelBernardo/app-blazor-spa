namespace Projeto_SPA_Blazor.Contracts.V1.Product
{
    public class ProductResponse
    {
        public int Id { get; set; }

        public string Title { get; set; } = null!;

        public decimal Price { get; set; }

        public int CategoryId { get; set; }
    }
}

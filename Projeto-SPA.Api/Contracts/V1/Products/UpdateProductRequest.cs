using System.ComponentModel.DataAnnotations;

namespace Projeto_SPA.Api.Contracts.V1.Products
{
    public class UpdateProductRequest
    {
        [Required(ErrorMessage = "Title is required")]
        [StringLength(100, MinimumLength = 2,
            ErrorMessage = "Title must be between 2 and 100 characters")]
        public required string Title { get; set; }

        [Range(0.01, double.MaxValue,
            ErrorMessage = "Price must be greater than 0")]
        public decimal Price { get; set; }

        [Range(1, int.MaxValue,
            ErrorMessage = "CategoryId must be a valid id")]
        public int CategoryId { get; set; }
    }
}

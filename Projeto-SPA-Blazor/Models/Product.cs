using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace Projeto_SPA_Blazor.Models
{
    public class Product
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Title is required")]
        [MaxLength(100, ErrorMessage = "Title must have a maximum of 100 characteres")]
        [MinLength(3, ErrorMessage = "Title must have a minimum of 3 characteres")]
        public string Title { get; set; } = string.Empty;

        [Required(ErrorMessage = "Price is required")]
        [DataType(DataType.Currency)]
        [Range(1, 10000, ErrorMessage = "Price must be between 1 and 10000")]
        [Precision(7, 2)]
        public decimal Price { get; set; }

        [Required(ErrorMessage = "Category is required")]
        [Range(1, 10000, ErrorMessage = "Category must be chosen")]
        public int CategoryId { get; set; }

        public Category Category { get; set; } = null!;
    }
}

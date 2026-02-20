using System.ComponentModel.DataAnnotations;

namespace Projeto_SPA_Blazor.Models
{
    public class Category
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Title is required")]
        [MaxLength(100, ErrorMessage = "Title must have a maximum of 100 characteres")]
        [MinLength(3, ErrorMessage = "Title must have a minimum of 3 characteres")]
        public string Title { get; set; } = string.Empty;

        public List<Product> Products { get; set; } = new();
    }
}

using System.ComponentModel.DataAnnotations;

namespace Projeto_SPA.Api.Contracts.V1.Categories
{
    public class UpdateCategoryRequest
    {
        [Required(ErrorMessage = "Title is required")]
        [StringLength(100, MinimumLength = 2,
            ErrorMessage = "Title must be between 2 and 100 characters")]
        public required string Title { get; set; }
    }
}

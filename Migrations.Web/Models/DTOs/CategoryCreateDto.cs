using System.ComponentModel.DataAnnotations;

namespace Migrations.Web.Models.DTOs
{
    public class CategoryCreateDto
    {
        [Required(ErrorMessage = "Name is required")]
        public string CategoryName { get; set; }

        [Required(ErrorMessage = "Description is required")]
        public string Description { get; set; }
    }
}

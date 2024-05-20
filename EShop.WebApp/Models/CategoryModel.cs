using System.ComponentModel.DataAnnotations;

namespace EShop.Models
{
    public class CategoryModel 
    {

        public int Id { get; set; }

        [Required(ErrorMessage = "Name is required")]
        [StringLength(100, ErrorMessage = "Name at most could be 100 character")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Description is required")]
        [StringLength(1000, ErrorMessage = "Description at most could be 1000 character")]
        public string Description { get; set; }
    }
   
}

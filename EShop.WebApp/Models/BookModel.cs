using System.ComponentModel.DataAnnotations;

namespace EShop.Models
{
    public class BookModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Title is required")]
        [StringLength(100, ErrorMessage = "Title at most could be 100 character")]
        public string Title { get; set; }

        [Required(ErrorMessage = "Publisher is required")]
        [StringLength(100, ErrorMessage = "Publisher at most could be 100 character")]
        public string Publisher { get; set; }

        [Required(ErrorMessage = "language is required")]
        [StringLength(100, ErrorMessage = "language at most could be 100 character")]
        public string language { get; set; }

        public DateTime PublishDate { get; set; }

        [Required(ErrorMessage = "Number of Pages is required")]
        public int Pages { get; set; }

        [Required(ErrorMessage = "Number Of Copies is required")]
        public int NumOfCopies { get; set; }

        [Required(ErrorMessage = "Available Number Of Copies is required")]
        public int AvailNumOfCopies { get; set; }

        [Required(ErrorMessage = "Bar Code is required")]
        [StringLength(100, ErrorMessage = "Bar Code at most could be 100 character")]
        public string BarCode { get; set; }

        [Required(ErrorMessage = "Imgage Path is required")]
        [StringLength(100, ErrorMessage = "Imgage Path at most could be 100 character")]
        public string ImgPath { get; set; }
        public string ImgName { get; set; }

        public IFormFile file { get; set; }
        public BookAuthorModel BookAuthor { get; set; }

        public BookCategoryModel BookCategory { get; set; }
    }
}

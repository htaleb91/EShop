using CukurovaLibrary.Entities.Domain;
using CukurovaLibrary.Services;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace EShop.Models
{
    public class BookCategoryModel
    {
        private readonly IBookService _bookService;
        private readonly ICategoryService _categoryService;


        public BookCategoryModel()
        {
            
        }
        public BookCategoryModel(IBookService bookAuthor, ICategoryService categoryService)
        {
            _bookService = bookAuthor;
            _categoryService = categoryService;
        }

        public int Id { get; set; }

        [Required(ErrorMessage = "Author is required")]
        public int BookId { get; set; }

        public IList<SelectListItem> ListOfBooks { get; set; }

        [Required(ErrorMessage = "Author is required")]
        public int CategoryId { get; set; }

        public IList<SelectListItem> ListOfCategories { get; set; }

        //public async Task<IList<SelectListItem>> GetAllBooks()
        //{
        //    var books = new List<SelectListItem>();
        //    books.Add(new SelectListItem { Text = "All", Value = "0", Selected = true });
        //    var list = await _bookService.GetAllBooks();
        //    foreach (var item in list)
        //    {
        //        books.Add(new SelectListItem { Text = item.Title, Value = item.Id.ToString(), Selected = true });
        //    }
        //    return books;
        //}

       

    }
}

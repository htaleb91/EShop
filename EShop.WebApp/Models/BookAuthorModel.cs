using CukurovaLibrary.Entities.Domain;
using CukurovaLibrary.Services;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace EShop.Models
{
    public class BookAuthorModel
    {
        private readonly IBookService _bookService;
        private readonly IAuthorService _authorService;

        public BookAuthorModel()
        {

        }
        public BookAuthorModel(IBookService bookAuthor, IAuthorService authorervice)
        {
            _bookService = bookAuthor;
            _authorService = authorervice;
           
        }

        public int Id { get; set; }

        [Required(ErrorMessage = "Author is required")]
        public int BookId { get; set; }

        public IList<SelectListItem>? ListOfBooks { get; set; }

        [Required(ErrorMessage = "Author is required")]
        public int AuthorId { get; set; }

        public IList<SelectListItem>? ListOfAuthors { get; set; }

        
    }
}

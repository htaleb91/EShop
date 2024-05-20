using CukurovaLibrary.Services;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace EShop.Models
{
    public class BorroweModel
    {
        private readonly IBookService _bookService;
        private readonly IUserService _userService;

        public BorroweModel(IBookService bookService, IUserService userService)
        {
            _bookService = bookService;
            _userService = userService;
        }
        public int Id { get; set; }

        [Required(ErrorMessage = "Borrowe Date is required")]
        public DateTime BorroweDate { get; set; }

        [Required(ErrorMessage = "Due Date is required")]
        public DateTime DueDate { get; set; }

        [Required(ErrorMessage = "Book is required")]
        public int BookId { get; set; }
        public IList<SelectListItem> ListOfBooks { get; set; }

        [Required(ErrorMessage = "User is required")]
        public int UserId { get; set; }
        public IList<SelectListItem> ListOfUsers { get; set; }

        public async Task<IList<SelectListItem>> GetAllBooks()
        {
            var books = new List<SelectListItem>();
            books.Add(new SelectListItem { Text = "All", Value = "0", Selected = true });
            var list = await _bookService.GetAllBooks();
            foreach (var item in list)
            {
                books.Add(new SelectListItem { Text = item.Title, Value = item.Id.ToString(), Selected = true });
            }
            return books;
        }
        
        public async Task<IList<SelectListItem>> GetAllUsers()
        {
            var users = new List<SelectListItem>();
            users.Add(new SelectListItem { Text = "All", Value = "0", Selected = true });
            var list = await _userService.GetAllUsers();
            foreach (var item in list)
            {
                users.Add(new SelectListItem { Text = item.FirstName + " " + item.SureName, Value = item.Id.ToString(), Selected = true });
            }
            return users;
        }
    }
}

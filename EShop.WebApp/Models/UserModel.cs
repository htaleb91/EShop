using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace EShop.Models
{
    public class UserModel
    {
        public UserModel()
        {
            Genders = new List<SelectListItem>();
            Genders.Add(new SelectListItem {Text= "Male", Value="Male" });
            Genders.Add(new SelectListItem { Text = "Female", Value = "Female" });
        }
        public int Id { get; set; }

        [Required(ErrorMessage = "First Name is required")]
        [StringLength(30, ErrorMessage = "First Name at most could be 30 character")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Sure Name is required")]
        [StringLength(20, ErrorMessage = "Sure Name at most could be 20 character")]
        public string SureName { get; set; }

        [Required(ErrorMessage = "Gender is required")]
        public string Gender { get; set; }
        public  IList<SelectListItem> Genders { get; set; }

        [Required(ErrorMessage = "Id Card No is required")]
        [StringLength(11, ErrorMessage = "Id Card No at most could be 11 character")]
        public string IdCardNo { get; set; }

        [Required(ErrorMessage = "Telefon Nunber is required")]
        [StringLength(11, ErrorMessage = "Telefon Nunber at most could be 11 character. e.g: 05xxxxxxxxx ")]
        public string TelNo { get; set; }

        [Required(ErrorMessage = "Address is required")]
        [StringLength(500, ErrorMessage = "Address at most could be 500 character")]
        public string Address { get; set; }

        [Required(ErrorMessage = "Email is required")]
        [EmailAddress(ErrorMessage = "Email is not correct. e.g: non@non.com")]
        [StringLength(30, ErrorMessage = "Email at most could be 30 character")]
        public string Email { get; set; }
    }
}

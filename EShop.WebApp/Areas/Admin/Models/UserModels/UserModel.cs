using EShop.Entities.Domain;
using EShop.Entities.Enums;
using EShop.Framework.Models;
using EShop.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations.Schema;


namespace EShop.Areas.Admin.Models.UserModels
{
    public record UserModel : BaseEShopIdentityEntityModel
    {
        public int UserId { get; set; }
        public string FirstName { get; set; }
        public string SureName { get; set; }
        public int GenderId { get; set; }
        public Gender _GenderEnum { get => (Gender)GenderId; set=> _GenderEnum = value; }
        public string Gender { get; set ;  } 
        public string IdCardNo { get; set; }
        public string TelNo { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public int PictureId { get; set; }
        public IFormFile PictureFile { get; set; }
        public Picture ProfilePicture { get; set; }
        public string PictureUrl { get; set; }
        public List<int> RoleIds { get; set; }
        public IList<SelectListItem> Roles { get; set; }
        public IList<SelectListItem> AvailableRoles { get; set; }

    }
}

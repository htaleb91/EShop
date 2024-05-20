using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EShop.Entities.Domain
{
    public class User: IdentityUser
    {
        //[Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int UserId { get; set; }
        public string FirstName { get; set; }
        public string SureName { get; set; }
        public string Gender { get; set; }
        public string IdCardNo { get; set; }
        public string TelNo { get; set; }
        public string Address { get; set; }
        public int AddressId { get; set; }
        public Address AddressDetails { get; set; }
        //public string Email { get; set; }
        public int? PictureId { get; set; }
        [ForeignKey("PictureId")]
        public Picture ProfilePicture { get; set; }

    }
}

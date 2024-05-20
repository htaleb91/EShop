using EShop.Framework.Models;

namespace EShop.Areas.Admin.Models.UserModels
{
    public record UserRoleModel : BaseEShopIdentityEntityModel
    {
        public int RoleId { get; set; }
        public string RoleName { get; set; }
        public string NormalizedName { get; set; }

    }
}

using EShop.Framework.Models;

namespace EShop.Areas.Admin.Models.ProductModels
{
    public record ProductTagModel : BaseEShopEntityModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}

using EShop.Framework.Models;

namespace EShop.Areas.Admin.Models.ProductModels
{
    public record ProductShippingModel :BaseEShopEntityModel
    {
        public bool IsShipEnabled { get; set; }
        public bool IsFreeShipping { get; set; }
        public decimal AdditionalShippingCharge { get; set; }
    }
}

using EShop.Framework.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace EShop.Areas.Admin.Models.ProductModels
{
    public record ProductMeasurmentModel : BaseEShopEntityModel
    {
        public decimal Weight { get; set; }

        public decimal Height { get; set; }

        public decimal Width { get; set; }

        public decimal Length { get; set; }
    }
}

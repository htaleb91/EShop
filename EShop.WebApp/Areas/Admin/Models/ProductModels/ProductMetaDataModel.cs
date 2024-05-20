using EShop.Framework.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace EShop.Areas.Admin.Models.ProductModels
{
    public record ProductMetaDataModel : BaseEShopEntityModel
    {
        public string MetaKeywords { get; set; }

        public string MetaTitle { get; set; }

        public string MetaDescription { get; set; }
    }
}

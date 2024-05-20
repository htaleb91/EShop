using entities=EShop.Entities.Domain;
using System.ComponentModel.DataAnnotations.Schema;
using EShop.Framework.Models;

namespace EShop.Areas.Admin.Models.ProductModels
{
    public record ProductPictureModel : BaseEShopEntityModel
    {
        public int ProductId { get; set; }
        public entities.Product Product { get; set; }

        public int PictureId { get; set; }
        public entities.Picture Picture { get; set; }
        public string Alt { get; set; }
        public string Description { get; set; }
        public string Src { get; set; }
    }
}

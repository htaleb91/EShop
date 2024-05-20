using EShop.Entities.Domain;
using EShop.Framework.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace EShop.Areas.Admin.Models.ProductModels
{
    public record ProductModel : BaseEShopEntityModel
    {

        public int Id { get; set; }
        public required string Name { get; set; }

        public string ShortDescription { get; set; }

        public string FullDescription { get; set; }

        public int BrandId { get; set; }
        public Brand Brand { get; set; }

        public int Quantity { get; set; }

        public int OrderMinQuantity { get; set; }

        public int OrderMaxQuantity { get; set; }

        public decimal Cost { get; set; }


        public decimal Price { get; set; }

        public bool ShowOnHomePage { get; set; }
        public bool AllowCustomrReviews { get; set; }
        public bool DisableBuyButton { get; set; }
        public bool DisableWishListButton { get; set; }
        public bool AvailableForPreOrder { get; set; }
        public bool CallForPrice { get; set; }
        public bool MarkAsNew { get; set; }
        public DateTime MarkAsNewStartDateTimeOnUtc { get; set; }
        public DateTime MarkAsNewEndDateTimeOnUtc { get; set; }

        public bool Published { get; set; }
        public bool Deleted { get; set; }

        public IList<Category> Categories { get; set; }
        public IList<Picture> Images { get; set; }
        public IList<ProductTag> ProductTags { get; set; }
        public IList<ProductReview> ProductReviews { get; set; }

        public ProductMeasurmentModel MeasurmentModel { get; set; }
        public ProductShippingModel ShippingModel { get; set; }
        public ProductMetaDataModel MetaDataModel { get; set; }
        public ProductSearchModel SearchModel { get; set; }

    }
}

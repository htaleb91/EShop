using System.ComponentModel.DataAnnotations.Schema;

namespace EShop.Entities.Domain
{
    public class Product : BaseEntity
    {
        
        [Column(TypeName = "nvarchar(MAX)")]
        public required string Name { get; set; }

        [Column(TypeName = "nvarchar(MAX)")]
        public string ShortDescription { get; set; }

        [Column(TypeName = "nvarchar(MAX)")]
        public string FullDescription { get; set; }

        public int BrandId { get; set; }
        [ForeignKey("BrandId")]
        public Brand Brand { get; set; }

        public int Quantity { get; set; }

        public int OrderMinQuantity { get; set; }

        public int OrderMaxQuantity { get; set; }

        [Column(TypeName = "decimal(18,4)")]
        public decimal Cost { get; set; }
        
        
        [Column(TypeName = "decimal(18,4)")]
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



        #region Measurement
        [Column(TypeName = "decimal(18,4)")]
        public decimal Weight { get; set; }

        [Column(TypeName = "decimal(18,4)")]
        public decimal Height { get; set; }

        [Column(TypeName = "decimal(18,4)")]
        public decimal Width { get; set; }

        [Column(TypeName = "decimal(18,4)")]
        public decimal Length { get; set; }
        #endregion

        #region Shipment

        public bool IsShipEnabled { get; set; }
        public bool IsFreeShipping { get; set; }
        public decimal AdditionalShippingCharge { get; set;}

        public int ShipmentId { get; set; }
        [ForeignKey("ShipmentId")]
        public Shipment Shipment { get; set; }

        #endregion


        #region Meta

        [Column(TypeName = "nvarchar(MAX)")]
        public string MetaKeywords { get; set; }

        [Column(TypeName = "nvarchar(MAX)")]
        public string MetaTitle { get; set; }

        [Column(TypeName = "nvarchar(MAX)")]
        public  string MetaDescription { get; set; }

        #endregion


    }
}

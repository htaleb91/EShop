using System.ComponentModel.DataAnnotations.Schema;

namespace EShop.Entities.Domain
{
    public class Order: BaseEntity
    {
        public Guid OrderGuid { get; set; }
        public string OrderCustomNumber { get; set; }

        //[ForeignKey("CustomerId")]
        public User Customer { get; set; }
        public int CustomerId { get; set; }
        public bool Deleted { get; set; }
        public int BillingAddressId { get; set; }
        public Address BillingAddress { get; set; }
        public int ShippingAddressId { get; set; }
        public Address ShippingAddress { get; set; }
        public int OrderStatusId { get; set; }
        public int ShippingStatusId { get; set; }


        public int ShipmentId { get; set; }
        [ForeignKey("ShipmentId")]
        public Shipment Shipment { get; set; }
        public int PaymentStatusId { get; set; }
        
        [Column(TypeName = "decimal(18,4)")]
        public decimal OrderSubTotal { get; set; }

        [Column(TypeName = "decimal(18,4)")]
        public decimal OrderTax { get; set; }

        [Column(TypeName = "decimal(18,4)")]
        public decimal OrderSubTotalIncLudeTax { get; set; }

        [Column(TypeName = "decimal(18,4)")]
        public decimal OrderSubTotalExcludeTax { get; set; }


        [Column(TypeName = "decimal(18,4)")]
        public decimal OrderShipping { get; set; }

        [Column(TypeName = "decimal(18,4)")]
        public decimal OrderShippingIncLudeTax { get; set; }

        [Column(TypeName = "decimal(18,4)")]
        public decimal OrderShippingExcludeTax { get; set; }


        [Column(TypeName = "decimal(18,4)")]
        public decimal OrderDiscount { get; set; }

        [Column(TypeName = "decimal(18,4)")]
        public decimal OrderDiscountIncLudeTax { get; set; }

        [Column(TypeName = "decimal(18,4)")]
        public decimal OrderDiscountExcludeTax { get; set; }


        #region Card
        public bool IsAllowingSaveCardInformation { get; set; }

        [Column(TypeName = "nvarchar(MAX)")]
        public string CardType { get; set; }

        [Column(TypeName = "nvarchar(MAX)")]
        public string CardName { get; set; }

        [Column(TypeName = "nvarchar(MAX)")]
        public string CardNumber { get; set; }

        [Column(TypeName = "nvarchar(MAX)")]
        public string MaskerCreditCardNumber { get; set; }

        [Column(TypeName = "nvarchar(MAX)")]
        public string CardCcv { get; set; }

        [Column(TypeName = "nvarchar(MAX)")]
        public string CardExpirationDateMonth { get; set; }

        [Column(TypeName = "nvarchar(MAX)")]
        public string CardExpirationDateYear { get; set; }

        [Column(TypeName = "nvarchar(MAX)")]
        public string AuthorizationTransactionId { get; set; }

        [Column(TypeName = "nvarchar(MAX)")]
        public string AuthorizationTransactionCode { get; set; }

        [Column(TypeName = "nvarchar(MAX)")]
        public string AuthorizationTransactionResult { get; set; }

        [Column(TypeName = "nvarchar(MAX)")]
        public DateTime PaidDate { get; set; }
        #endregion
    }
}

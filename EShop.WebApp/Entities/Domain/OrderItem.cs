using System.ComponentModel.DataAnnotations.Schema;

namespace EShop.Entities.Domain
{
    public class OrderItem : BaseEntity
    {
        public int ProductId { get; set; }
        [ForeignKey("ProductId")]
        public Product Product { get; set; }

        public int OrderId { get; set; }
        [ForeignKey("OrderId")]
        public Order Order { get; set; }

        public Guid OrderItemGuid { get; set; }

        public int Quantity { get; set; }
        [Column(TypeName = "decimal(18,4)")]
        public decimal UnitPriceIncludeTax { get; set; }
        [Column(TypeName = "decimal(18,4)")]
        public decimal UnitPriceExcludeTax { get; set; }

        [Column(TypeName = "decimal(18,4)")]
        public decimal PriceIncludeTax { get; set; }
        [Column(TypeName = "decimal(18,4)")]
        public decimal PriceExcludeTax { get; set; }

        [Column(TypeName = "decimal(18,4)")]
        public decimal DiscountAmountIncludeTax { get; set; }
        [Column(TypeName = "decimal(18,4)")]
        public decimal DiscountAmountExcludeTax { get; set; }

        [Column(TypeName = "decimal(18,4)")]
        public decimal OriginalProductCost { get; set; }

        [Column(TypeName = "decimal(18,4)")]
        public decimal ItemWeight { get; set; }

    }
}

using System.ComponentModel.DataAnnotations.Schema;

namespace EShop.Entities.Domain
{
    public class DiscountUsageHistory :BaseEntity
    {
        public int OrderId { get; set; }
        [ForeignKey("OrderId")]
        public Order Order { get; set; }


        public int DiscountId { get; set; }
        [ForeignKey("DiscountId")]
        public Discount Discount { get; set; }

    }
}

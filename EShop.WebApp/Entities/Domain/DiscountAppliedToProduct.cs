using System.ComponentModel.DataAnnotations.Schema;

namespace EShop.Entities.Domain
{
    public class DiscountAppliedToProduct : BaseEntity
    {
        public int ProductId { get; set; }
        [ForeignKey("ProductId")]
        public Product Product { get; set; }


        public int DiscountId { get; set; }
        [ForeignKey("DiscountId")]
        public Discount Discount { get; set; }

    }
}

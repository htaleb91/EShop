using System.ComponentModel.DataAnnotations.Schema;

namespace EShop.Entities.Domain
{
    public class DiscountAppliedToCategory : BaseEntity
    {
        public int CategoryId { get; set; }
        [ForeignKey("CategoryId")]
        public Category Category { get; set; }


        public int DiscountId { get; set; }
        [ForeignKey("DiscountId")]
        public Discount Discount { get; set; }
    }
}

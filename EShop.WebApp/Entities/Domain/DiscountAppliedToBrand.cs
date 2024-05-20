using System.ComponentModel.DataAnnotations.Schema;

namespace EShop.Entities.Domain
{
    public class DiscountAppliedToBrand : BaseEntity
    {

        public int BrandId { get; set; }
        [ForeignKey("BrandId")]
        public Brand Brand { get; set; }


        public int DiscountId { get; set; }
        [ForeignKey("DiscountId")]
        public Discount Discount { get; set; }

    }
}

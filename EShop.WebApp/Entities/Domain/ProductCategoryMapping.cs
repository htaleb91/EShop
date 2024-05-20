using System.ComponentModel.DataAnnotations.Schema;

namespace EShop.Entities.Domain
{
    public class ProductCategoryMapping : BaseEntity
    {

        public int ProductId { get; set; }
        [ForeignKey("ProductId")]
        public Product Product { get; set; }

        public int CategoryId { get; set; }
        [ForeignKey("CategoryId")]
        public Category Category { get; set; }
    }
}

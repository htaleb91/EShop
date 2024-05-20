using System.ComponentModel.DataAnnotations.Schema;

namespace EShop.Entities.Domain
{
    public class ProductProductTagMapping : BaseEntity
    {
        public int ProductId { get; set; }

        [ForeignKey("ProductId")]
        public Product Product { get; set; }

        public int ProductTagId { get; set; }
        
        [ForeignKey("ProductTagId")]
        public ProductTag ProductTag { get; set; }
    }
}

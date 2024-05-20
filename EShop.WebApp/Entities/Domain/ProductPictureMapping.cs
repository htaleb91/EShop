using System.ComponentModel.DataAnnotations.Schema;

namespace EShop.Entities.Domain
{
    public class ProductPictureMapping:BaseEntity
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        [ForeignKey("ProductId")]
        public Product Product { get; set; }

        public int PictureId { get; set; }
        [ForeignKey("PictureId")]
        public Picture Picture { get; set; }
    }
}

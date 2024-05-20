using System.ComponentModel.DataAnnotations.Schema;

namespace EShop.Entities.Domain
{
    public class ProductReview : BaseEntity
    {
        public int CustomerId { get; set; }
       // [ForeignKey("CustomerId")]
        public User Customer { get; set; }

        public int ProductId { get; set; }
        [ForeignKey("ProductId")]
        public Product Product { get; set; }

        public bool IsApproved { get; set; }

        [Column(TypeName ="nvarchar(MAX)")]
        public string Title { get; set; }

        [Column(TypeName = "nvarchar(MAX)")]
        public string ReviewText { get; set; }

        [Column(TypeName = "nvarchar(MAX)")]
        public string ReplyText { get; set; }

        public int Rating { get; set; }

        public int HelpfullYesTotal { get; set; }
        public int helpfullNoTotal { get; set; }
    }
}

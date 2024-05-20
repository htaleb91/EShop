using System.ComponentModel.DataAnnotations.Schema;

namespace EShop.Entities.Domain
{
    public class OrderNote : BaseEntity
    {
        [Column(TypeName = "nvarchar(MAX)")]
        public string Note { get; set; }

        public int OrderId { get; set; }
        [ForeignKey("OrderId")]
        public Order Order { get; set; }

        public bool DisplayToCustomer { get; set; }
    }
}

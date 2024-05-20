using System.ComponentModel.DataAnnotations.Schema;

namespace EShop.Entities.Domain
{
    public class Shipment : BaseEntity
    {
        public int OrderId { get; set; }
        [ForeignKey("OrderId")]
        public Order Order { get; set; }

        [Column(TypeName = ("nvarchar(MAX)"))]
        public string TrackingNumber { get; set; }

        [Column(TypeName = ("nvarchar(MAX)"))]
        public string TotalWeight { get; set; }

        [Column(TypeName = ("nvarchar(MAX)"))]
        public string ShippedDateUtc { get; set; }

        [Column(TypeName = ("nvarchar(MAX)"))]
        public string ExpectedDelivaryDateUtc { get; set; }

        [Column(TypeName = ("nvarchar(MAX)"))]
        public string DelivaryDateUtc { get; set; }

        [Column(TypeName = ("nvarchar(MAX)"))]
        public string AdminComment { get; set; }

    }
}

using System.ComponentModel.DataAnnotations.Schema;

namespace EShop.Entities.Domain
{
    public class ShipmentItem : BaseEntity
    {
        public int ShipmentId { get; set; }

        [ForeignKey("ShipmentId")]
        public Shipment Shipment { get; set; }


        public int OrderItemId { get; set; }

        [ForeignKey("OrderItemId")]
        public OrderItem OrderItem { get; set; }


        public int Quantity { get; set; }
    }
}

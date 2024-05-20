namespace EShop.Entities.Domain
{
    public class Discount : BaseEntity
    {
        public string Name { get; set; }

        public bool IsCouponequired { get; set; }
        public string CouponCode { get; set; }

        public string AdminComment { get; set; }

        public bool UsePerncentage { get; set; }

        public decimal DiscountPercentage { get; set; }

        public decimal DiscountAmount { get; set; }

        public decimal MaxDiscountAmount { get; set; }

        public DateTime StartDateUtc { get; set; }

        public DateTime EndDateUtc { get; set; }

        public int MaxDiscountedQuantity { get; set; }


    }
}

namespace EShop.Entities.Domain
{
    public class LocalizedContent : BaseEntity
    {
        public string Language { get; set; }

        public string LocaleKeygroup { get; set; }

        public string LocaleKey { get; set; }

        public string LocaleValue { get; set; }

        public int EntityId { get; set; }
    }
}

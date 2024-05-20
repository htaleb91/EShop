namespace EShop.Entities.Domain
{
    public class Picture:BaseEntity
    {

        public byte[] Bytes { get; set; }
        public string Description { get; set; }
        public string FileExtension { get; set; }
        public decimal Size { get; set; }
    }
}

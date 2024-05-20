using System.ComponentModel.DataAnnotations.Schema;

namespace EShop.Entities.Domain
{
    public class ProductTag : BaseEntity
    {
        [Column(TypeName =("nvarchar(MAX)"))]
        public string Name { get; set; }
    }
}

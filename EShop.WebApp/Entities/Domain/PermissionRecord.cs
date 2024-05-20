using System.ComponentModel.DataAnnotations.Schema;

namespace EShop.Entities.Domain
{
    public class PermissionRecord : BaseEntity
    {
        [Column(TypeName ="nvarchar(MAX)")]
        public string Name { get; set; }
        [Column(TypeName = "nvarchar(MAX)")]
        public string SystemName { get; set; }
        
        [Column(TypeName ="nvarchar(MAX)")]
        public string Category { get; set; }
    }
}

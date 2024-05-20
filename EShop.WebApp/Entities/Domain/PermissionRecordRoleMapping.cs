using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;

namespace EShop.Entities.Domain
{
    public class PermissionRecordRoleMapping : BaseEntity
    {
        public int RoleId { get; set; }
       // [ForeignKey("RoleId")]
        public UserRole Role { get; set; }

        public int PermissionRecordId { get; set; }
        [ForeignKey("PermissionRecordId")]
        public PermissionRecord PermissionRecord { get; set; }
    }
}

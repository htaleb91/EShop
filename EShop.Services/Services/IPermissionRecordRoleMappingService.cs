using EShop.Entities.Domain;

namespace EShop.Services
{
    public interface IPermissionRecordRoleMappingService
    {
        Task DeletePermissionRecordRoleMapping(int id);
        Task DeletePermissionRecordRoleMapping(PermissionRecordRoleMapping PermissionRecordRoleMapping);
        Task<IList<PermissionRecordRoleMapping>> GetAllPermissionRecordRoleMappings();
        Task<PermissionRecordRoleMapping> GetPermissionRecordRoleMapping(int id);
        Task InsertPermissionRecordRoleMapping(PermissionRecordRoleMapping PermissionRecordRoleMapping);
        Task UpdatePermissionRecordRoleMapping(PermissionRecordRoleMapping PermissionRecordRoleMapping);
    }
}
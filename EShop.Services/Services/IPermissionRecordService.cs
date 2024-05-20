using EShop.Entities.Domain;

namespace EShop.Services
{
    public interface IPermissionRecordService
    {
        Task DeletePermissionRecord(int id);
        Task DeletePermissionRecord(PermissionRecord PermissionRecord);
        Task<IList<PermissionRecord>> GetAllPermissionRecords();
        Task<PermissionRecord> GetPermissionRecord(int id);
        Task InsertPermissionRecord(PermissionRecord PermissionRecord);
        Task UpdatePermissionRecord(PermissionRecord PermissionRecord);
    }
}
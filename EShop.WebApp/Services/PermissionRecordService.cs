using EShop.Data;
using EShop.Entities.Domain;
using Microsoft.EntityFrameworkCore;

namespace EShop.Services
{
    public class PermissionRecordService : IPermissionRecordService
    {

        private ApplicationDbContext _dbContext;

        public PermissionRecordService(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IList<PermissionRecord>> GetAllPermissionRecords()
        {
            var context = _dbContext.PermissionRecords;
            return await context.ToListAsync();

        }
        public async Task<PermissionRecord> GetPermissionRecord(int id)
        {

            var context = _dbContext.PermissionRecords;
            var permissionRecord = context.FirstOrDefault(b => b.Id == id);
            return permissionRecord;
        }

        public async Task InsertPermissionRecord(PermissionRecord permissionRecord)
        {
            var context = _dbContext.PermissionRecords;
            var pr = context.FirstOrDefault(b => b.Id == permissionRecord.Id);
            if (pr is null )
            {
                permissionRecord.CreatedOnUtc = DateTime.UtcNow;
                await context.AddAsync(permissionRecord);
                _dbContext.SaveChanges();
            }
            
        }

        public async Task UpdatePermissionRecord(PermissionRecord permissionRecord)
        {
            var context = _dbContext.PermissionRecords;
            var pr = context.FirstOrDefault(b => b.Id == permissionRecord.Id);
            if (pr is not null)
            {
                permissionRecord.UpdatedOnUtc = DateTime.UtcNow;
                context.Update(permissionRecord);
                _dbContext.SaveChanges();
            }
            
        }

        public async Task DeletePermissionRecord(PermissionRecord permissionRecord)
        {
            var context = _dbContext.PermissionRecords;
            var pr = context.FirstOrDefault(b => b.Id == permissionRecord.Id);

            if (pr is not null)
            {
                context.Remove(pr);
                _dbContext.SaveChanges();
            }
        }



        public async Task DeletePermissionRecord(int id)
        {
            var context = _dbContext.PermissionRecords;
            var permissionRecord = context.FirstOrDefault(b => b.Id == id);
                        
            if (permissionRecord is not null)
            {
                context.Remove(permissionRecord);
                _dbContext.SaveChanges();
            }
        }

    }
}

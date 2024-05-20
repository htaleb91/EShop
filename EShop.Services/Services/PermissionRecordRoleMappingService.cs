using EShop.Data;
using EShop.Entities.Domain;
using Microsoft.EntityFrameworkCore;

namespace EShop.Services
{
    public class PermissionRecordRoleMappingService : IPermissionRecordRoleMappingService
    {

        private ApplicationDbContext _dbContext;

        public PermissionRecordRoleMappingService(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IList<PermissionRecordRoleMapping>> GetAllPermissionRecordRoleMappings()
        {
            // _dbContext.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
            var context = _dbContext.PermissionRecordRoleMappings;
            return await context.ToListAsync();

        }
        public async Task<PermissionRecordRoleMapping> GetPermissionRecordRoleMapping(int id)
        {

            var context = _dbContext.PermissionRecordRoleMappings;
            var permissionRecordRoleMapping = context.Where(b => b.Id== id).FirstOrDefault();
            return permissionRecordRoleMapping;
        }

        public async Task InsertPermissionRecordRoleMapping(PermissionRecordRoleMapping permissionRecordRoleMapping)
        {
            //_dbContext.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
            var context = _dbContext.PermissionRecordRoleMappings;
            var permissionRoleMapp = context.Where(b => b.Id == permissionRecordRoleMapping.Id).FirstOrDefault();
            if (permissionRoleMapp is null)
            {
                permissionRecordRoleMapping.CreatedOnUtc = DateTime.UtcNow;
                await context.AddAsync(permissionRecordRoleMapping);
                _dbContext.SaveChanges();
            }
                
        }

        public async Task UpdatePermissionRecordRoleMapping(PermissionRecordRoleMapping permissionRecordRoleMapping)
        {
            var context = _dbContext.PermissionRecordRoleMappings;
            var permissionRoleMapp = context.Where(b => b.Id == permissionRecordRoleMapping.Id).FirstOrDefault();
            if (permissionRoleMapp is null)
            {
                permissionRecordRoleMapping.UpdatedOnUtc = DateTime.UtcNow;
                context.Update(permissionRecordRoleMapping);
                _dbContext.SaveChanges();
            }
            
        }

        public async Task DeletePermissionRecordRoleMapping(PermissionRecordRoleMapping permissionRecordRoleMapping)
        {
            var context = _dbContext.PermissionRecordRoleMappings;
            var permissionRoleMapping = (from b in context
                                         where b.Id == permissionRecordRoleMapping.Id
                                         select b).FirstOrDefault();


            if (permissionRoleMapping is not null)
            {
                context.Remove(permissionRecordRoleMapping);
                _dbContext.SaveChanges();
            }
        }



        public async Task DeletePermissionRecordRoleMapping(int id)
        {
            var context = _dbContext.PermissionRecordRoleMappings;
            var permissionRoleMapping = (from b in context
                        where b.Id == id
                        select b).FirstOrDefault();

            
            if (permissionRoleMapping is not null)
            {
                context.Remove(permissionRoleMapping);
                _dbContext.SaveChanges();
            }
        }

    }
}

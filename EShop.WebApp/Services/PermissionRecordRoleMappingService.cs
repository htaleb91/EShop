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
            var context = _dbContext.PermissionRecordRoleMappings;
            return await context.ToListAsync();

        }
        public async Task<PermissionRecordRoleMapping> GetPermissionRecordRoleMapping(int id)
        {

            var context = _dbContext.PermissionRecordRoleMappings;
            var permissionRecordRoleMapping = context.FirstOrDefault(b => b.Id== id);
            return permissionRecordRoleMapping;
        }

        public async Task InsertPermissionRecordRoleMapping(PermissionRecordRoleMapping permissionRecordRoleMapping)
        {
            var context = _dbContext.PermissionRecordRoleMappings;
            var permissionRoleMapp = context.FirstOrDefault(b => b.Id == permissionRecordRoleMapping.Id);
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
            var permissionRoleMapp = context.FirstOrDefault(b => b.Id == permissionRecordRoleMapping.Id);
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
            var permissionRoleMapping = context.FirstOrDefault(b => b.Id == permissionRecordRoleMapping.Id);


            if (permissionRoleMapping is not null)
            {
                context.Remove(permissionRecordRoleMapping);
                _dbContext.SaveChanges();
            }
        }



        public async Task DeletePermissionRecordRoleMapping(int id)
        {
            var context = _dbContext.PermissionRecordRoleMappings;
            var permissionRoleMapping = context.FirstOrDefault(b => b.Id == id);
            
            if (permissionRoleMapping is not null)
            {
                context.Remove(permissionRoleMapping);
                _dbContext.SaveChanges();
            }
        }

    }
}

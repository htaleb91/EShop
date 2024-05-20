using EShop.Data;
using EShop.Entities.Domain;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Drawing.Drawing2D;

namespace EShop.Services
{
    public class RoleService : IRoleService
    {

        private ApplicationDbContext _dbContext;

        public RoleService(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        #region User Roles
        public async Task<IList<UserRole>> GetAllUserRoles()
        {
            // _dbContext.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
            var context = _dbContext.User_Roles;
            return await context.ToListAsync();

        }

        public async Task<UserRole> GetUserRoleByRoleId(int RoleId)
        {
            
            var context = _dbContext.User_Roles;
            var role = context.Where(b => b.RoleId == RoleId).FirstOrDefault();
            return role;
        }


        public async Task InsertUserRole(UserRole role)
        {
            //_dbContext.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
            var context = _dbContext.User_Roles;
            var _role = context.Where(b => b.Id == role.Id).FirstOrDefault();
            if (_role is null)
            {
                //role.CreatedOnUtc = DateTime.UtcNow;
                await context.AddAsync(role);
                _dbContext.SaveChanges();
            }

        }

        public async Task UpdateUserRole(UserRole role)
        {
            var context = _dbContext.User_Roles;
            var _role = context.Where(b => b.Id == role.Id).FirstOrDefault();
            if (_role is not null)
            {
                //role = DateTime.UtcNow;
                context.Update(role);
                _dbContext.SaveChanges();

            }
        }

        public async Task DeleteUserRole(UserRole role)
        {
            var context = _dbContext.User_Roles;
            var query = from b in context
                        where b.Id.Equals(role.Id)
                        select b;

            var _role = query.FirstOrDefault();
            if (_role is not null)
            {
                //role.Deleted = true;
                context.Remove(role);
                _dbContext.SaveChanges();
            }
        }


        public async Task DeleteUserRoleByUserRoleId(int userRoleId)
        {
            var context = _dbContext.User_Roles;
            var query = from b in context
                        where b.RoleId == userRoleId
                        select b;

            var _role = query.FirstOrDefault();
            if (_role is not null)
            {
                //_role.Deleted = true;
                context.Remove(_role);
                _dbContext.SaveChanges();
            }
        }
        #endregion
        public async Task<IList<IdentityRole>> GetAllRoles()
        {
            // _dbContext.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
            var context = _dbContext.Roles;
            return await context.ToListAsync();

        }

   
        public async Task<IdentityRole> GetRole(string id)
        {

            var context = _dbContext.Roles;
            var role = context.Where(b => b.Id.Equals(id)).FirstOrDefault();
            return role;
        }
       

        public async Task InsertRole(IdentityRole role)
        {
            //_dbContext.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
            var context = _dbContext.Roles;
            var _role = context.Where(b => b.Id == role.Id).FirstOrDefault();
            if (_role is null)
            {
                //role.CreatedOnUtc = DateTime.UtcNow;
                await context.AddAsync(role);
                _dbContext.SaveChanges();
            }
                
        }

        public async Task UpdateRole(IdentityRole role)
        {
            var context = _dbContext.Roles;
            var _role = context.Where(b => b.Id == role.Id).FirstOrDefault();
            if (_role is not null)
            {
                //role = DateTime.UtcNow;
                context.Update(role);
                _dbContext.SaveChanges();

            }
        }

        public async Task DeleteRole(IdentityRole role)
        {
            var context = _dbContext.Roles;
            var query = from b in context
                        where b.Id == role.Id
                        select b;

            var _role = query.FirstOrDefault();
            if (_role is not null)
            {
                //role.Deleted = true;
                context.Remove(role);
                _dbContext.SaveChanges();
            }
        }



        public async Task DeleteRole(int id)
        {
            var context = _dbContext.Roles;
            var query = from b in context
                        where b.Id.Equals( id.ToString())
                        select b;

            var _role = query.FirstOrDefault();
            if (_role is not null)
            {
                //_role.Deleted = true;
                context.Remove(_role);
                _dbContext.SaveChanges();
            }
        }

       
    }
}

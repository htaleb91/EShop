using EShop.Data;
using EShop.Entities.Domain;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Data;
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
            var context = _dbContext.User_Roles;
            return await context.ToListAsync();

        }

        public async Task<UserRole> GetUserRoleByRoleId(int RoleId)
        {
            
            var context = _dbContext.User_Roles;
            var role = context.FirstOrDefault(b => b.RoleId == RoleId);
            return role;
        }


        public async Task InsertUserRole(UserRole role)
        {
            var context = _dbContext.User_Roles;
            var _role = context.FirstOrDefault(b => b.Id == role.Id);
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
            var _role = context.FirstOrDefault(b => b.Id == role.Id);
            if (_role is not null)
            {
                context.Update(role);
                _dbContext.SaveChanges();

            }
        }

        public async Task DeleteUserRole(UserRole role)
        {
            var context = _dbContext.User_Roles;
           

            var _role = context.FirstOrDefault(b=> b.Id.Equals(role.Id));
            if (_role is not null)
            {
                context.Remove(role);
                _dbContext.SaveChanges();
            }
        }


        public async Task DeleteUserRoleByUserRoleId(int userRoleId)
        {
            var context = _dbContext.User_Roles;
            

            var _role = context.FirstOrDefault(b=> b.RoleId == userRoleId);
            if (_role is not null)
            {
                context.Remove(_role);
                _dbContext.SaveChanges();
            }
        }
        #endregion
        public async Task<IList<IdentityRole>> GetAllRoles()
        {
            var context = _dbContext.Roles;
            return await context.ToListAsync();

        }

   
        public async Task<IdentityRole> GetRole(string id)
        {

            var context = _dbContext.Roles;
            var role = context.FirstOrDefault(b => b.Id.Equals(id));
            return role;
        }
       

        public async Task InsertRole(IdentityRole role)
        {
            var context = _dbContext.Roles;
            var _role = context.FirstOrDefault(b => b.Id.Equals( role.Id));
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
            var _role = context.FirstOrDefault(b => b.Id.Equals(role.Id));
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
            
            var _role = context.FirstOrDefault(b => b.Id.Equals(role.Id));
            if (_role is not null)
            {
                context.Remove(role);
                _dbContext.SaveChanges();
            }
        }



        public async Task DeleteRole(int id)
        {
            var context = _dbContext.Roles;
           

            var _role = context.FirstOrDefault(b => b.Id.Equals(id.ToString()));
            if (_role is not null)
            {
                //_role.Deleted = true;
                context.Remove(_role);
                _dbContext.SaveChanges();
            }
        }

       
    }
}

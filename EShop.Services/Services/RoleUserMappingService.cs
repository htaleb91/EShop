using EShop.Data;
using EShop.Entities.Domain;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Drawing.Drawing2D;

namespace EShop.Services
{
    public class UserRoleService : IUserRoleService
    {

        private ApplicationDbContext _dbContext;

        public UserRoleService(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IList<IdentityUserRole<string>>> GetAllUserRoles()
        {
            // _dbContext.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
            var context = _dbContext.UserRoles;
            return await context.ToListAsync();

        }
        public async Task<IList<IdentityUserRole<string>>> GetUserRole(string userId)
        {

            var context = _dbContext.UserRoles;
            var userRole =await context.Where(b => b.UserId.Equals(userId)).ToListAsync();
            return userRole;
        }
        
        public async Task InsertUserRole(IdentityUserRole<string> userRole)
        {
            //_dbContext.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
            var context = _dbContext.UserRoles;
            var _userRole = context.Where(b=>b.RoleId.Equals(userRole.RoleId) && b.UserId.Equals(userRole.UserId)).FirstOrDefault();
            if (_userRole is null)
            {
                //userRole.CreatedOnUtc = DateTime.UtcNow;
                await context.AddAsync(userRole);
                _dbContext.SaveChanges();
            }
                
        }

        public async Task UpdateUserRole(IdentityUserRole<string> userRole)
        {
            var context = _dbContext.UserRoles;
            var _userRole = context.Where(b => b.RoleId.Equals(userRole.RoleId) && b.UserId.Equals(userRole.UserId)).FirstOrDefault();
            if (_userRole is not null)
            {
                //userRole.UpdatedOnUtc = DateTime.UtcNow;
                context.Remove(userRole);
                _dbContext.SaveChanges();

            }
        }

        public async Task DeleteUserRole(IdentityUserRole<string> userRole)
        {
            var context = _dbContext.UserRoles;
            var query = from b in context
                        where b.RoleId.Equals(userRole.RoleId) && b.UserId.Equals(userRole.UserId)
                        select b;

            var _userRole = query.FirstOrDefault();
            if (_userRole is not null)
            {
                //userRole.Deleted = true;
                context.Remove(userRole);
                _dbContext.SaveChanges();
            }
        }



        //public async Task DeleteUserRole(int id)
        //{
        //    var context = _dbContext.UserRoles;
        //    var query = from b in context
        //                where b.RoleId.Equals(userRole.RoleId) && b.UserId.Equals(userRole.UserId)
        //                select b;

        //    var _userRole = query.FirstOrDefault();
        //    if (_userRole is not null)
        //    {
        //        _userRole.Deleted = true;
        //        context.Update(_userRole);
        //        _dbContext.SaveChanges();
        //    }
        //}

    }
}


using EShop.Data;
using EShop.Entities.Domain;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;


namespace EShop.Services
{

    public class UserService : IUserService
    {
        private ApplicationDbContext _dbContext;

        public UserService(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IList<User>> GetAllUsers()
        {
           // _dbContext.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
            var context = _dbContext.ApplicationUsers;
            return await context.ToListAsync();
          
        }
        public async Task<User> GetUser(int id)
        {
            
            var context = _dbContext.ApplicationUsers;
            var user = context.Where(b => b.UserId==id).FirstOrDefault();
            return user;
        }

        public async Task InsertUser(User user)
        {
           // _dbContext.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
            var context = _dbContext.ApplicationUsers;
            var _user= context.Where(b=> b.Id== user.Id).FirstOrDefault();
            if (_user is  null)
            {
                user.Id = Guid.NewGuid().ToString();
                await context.AddAsync(user);
                _dbContext.SaveChanges();

            }
        }

        public async Task UpdateUser(User user)
        {
            var context = _dbContext.ApplicationUsers;

           // var context = _dbContext.Users;
           // var _user = context.Where(b => b.Id.Equals(user.Id)).FirstOrDefault();
            
                context.Update(user);
                _dbContext.SaveChanges();
            
        }

        public async Task DeleteUser(User user)
        {
            var context = _dbContext.ApplicationUsers;
            var _user = (from b in context
                        where b.Id.Equals(user.Id.ToString())
                        select b).FirstOrDefault();


            if (_user is not null)
            {
                context.Remove(user);
                _dbContext.SaveChanges();
            }
            
        }

       public async Task DeleteSelectedUsers(IList<int> selectedIds)
        {
            var context = _dbContext.ApplicationUsers;
            foreach (var id in selectedIds)
            {
                var user = await GetUser(id);
                if (user is not null)
                {
                    context.Remove(user);
                    _dbContext.SaveChanges();
                }
            }
            
        }

        public async Task DeleteUser(int id)
        {
            var context = _dbContext.ApplicationUsers;
            var user = (from b in context
                        where b.Id.Equals(id.ToString())
                        select b).FirstOrDefault();

            
            if(user is not null)
            {
                context.Remove(user);
                _dbContext.SaveChanges();
            }
        }
    }
}
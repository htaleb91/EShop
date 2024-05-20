
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
            var context = _dbContext.ApplicationUsers;
            return await context.ToListAsync();
          
        }
        public async Task<User> GetUser(int id)
        {
            
            var context = _dbContext.ApplicationUsers;
            var user = context.FirstOrDefault(b => b.UserId ==id );
            return user;
        }

        public async Task InsertUser(User user)
        {
            var context = _dbContext.ApplicationUsers;
            var _user= context.FirstOrDefault(b => b.Id == user.Id);
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
            var _user = context.FirstOrDefault(b => b.Id == user.Id);


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
            var user = context.FirstOrDefault(b=> b.Id.Equals(id.ToString()));
                        
            if(user is not null)
            {
                context.Remove(user);
                _dbContext.SaveChanges();
            }
        }
    }
}
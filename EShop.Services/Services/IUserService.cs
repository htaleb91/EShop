using EShop.Entities.Domain;
using Microsoft.AspNetCore.Identity;

namespace EShop.Services
{
    public interface IUserService
    {
        Task DeleteSelectedUsers(IList<int> selectedIds);
        Task DeleteUser(int id);
        Task DeleteUser(User user);
        Task<IList<User>> GetAllUsers();
        Task<User> GetUser(int id);
        Task InsertUser(User user);
        Task UpdateUser(User user);
    }
}
using EShop.Entities.Domain;
using Microsoft.AspNetCore.Identity;

namespace EShop.Services
{
    public interface IRoleService
    {
        Task DeleteRole(IdentityRole role);
        Task DeleteRole(int id);
        Task DeleteUserRoleByUserRoleId(int id);
        Task DeleteUserRole(UserRole role);
        Task<IList<IdentityRole>> GetAllRoles();
        Task<IList<UserRole>> GetAllUserRoles();
        Task<IdentityRole> GetRole(string id);
        Task<UserRole> GetUserRoleByRoleId(int RoleId);
        Task InsertRole(IdentityRole role);
        Task InsertUserRole(UserRole role);
        Task UpdateRole(IdentityRole role);
        Task UpdateUserRole(UserRole role);
    }
}
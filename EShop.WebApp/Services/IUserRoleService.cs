using Microsoft.AspNetCore.Identity;

namespace EShop.Services
{
    public interface IUserRoleService
    {
        Task DeleteUserRole(IdentityUserRole<string> userRole);
        //Task DeleteUserRole(int id);
        Task<IList<IdentityUserRole<string>>> GetAllUserRoles();
        Task<IList<IdentityUserRole<string>>> GetUserRole(string userId);
        Task InsertUserRole(IdentityUserRole<string> userRole);
        Task UpdateUserRole(IdentityUserRole<string> userRole);
    }
}
using EShop.Areas.Admin.Models.UserModels;
using EShop.Entities.Domain;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace EShop.Areas.Admin.Factories
{
    public interface IUserModelFactory
    {
        Task<IList<SelectListItem>> GetAvailableRoles();
        Task<IList<SelectListItem>> GetUserRoles(string userId);
        Task<UserListModel> PrepareListModelAsync(UserSearchModel searchModel);
        Task<UserSearchModel> PrepareSearchModelAsync(UserSearchModel searchModel);
        Task<UserModel> PrepareUserModelAsync(UserModel? model, User? user);
    }
}
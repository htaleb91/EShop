using EShop.Entities.Domain;

namespace EShop.Services
{
    public interface ICategoryService
    {
        Task<IList<Category>> GetAllCategories();
        Task<Category> GetCategory(int id);
        Task InsertCategory(Category category);
        Task UpdateCategory(Category category);
        Task DeleteCategory(Category category);
        Task DeleteCategory(int id);
    }
}

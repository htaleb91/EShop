using EShop;
using EShop.Data;
using EShop.Entities.Domain;
using Microsoft.EntityFrameworkCore;


namespace EShop.Services
{
   

    public class CategoryService : ICategoryService
    {
        private ApplicationDbContext _dbContext;

        public CategoryService(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IList<Category>> GetAllCategories()
        {
            var context = _dbContext.Categories;
            return await context.ToListAsync();
          
        }
        public async Task<Category> GetCategory(int id)
        {
            
            var context = _dbContext.Categories;
            var category = context.FirstOrDefault(b => b.Id == id);
            return category;
        }

        public async Task InsertCategory(Category category)
        {
            var context = _dbContext.Categories;
            var _category= context.FirstOrDefault(b => b.Id == category.Id);
            if(_category is null)
            {
                category.UpdatedOnUtc = DateTime.UtcNow;
                await context.AddAsync(category);
                _dbContext.SaveChanges();
            }
        }

        public async Task UpdateCategory(Category category)
        {
            var context = _dbContext.Categories;
            var _category = context.FirstOrDefault(b => b.Id == category.Id);
            if (_category is not null)
            {
                category.UpdatedOnUtc = DateTime.UtcNow;
                context.Update(category);
                _dbContext.SaveChanges();
            }
        }

        public async Task DeleteCategory(Category category)
        {
            var context = _dbContext.Categories;
            
            var _category = context.FirstOrDefault(b => b.Id == category.Id);
            if (_category is not null)
            {
                category.Deleted = true;
                context.Update(category);
                _dbContext.SaveChanges();
            }
        }



        public async Task DeleteCategory(int id)
        {
            var context = _dbContext.Categories;
            
            var category = context.FirstOrDefault(b => b.Id == id);
            if(category is not null)
            {
                category.Deleted = true;
                context.Update(category);
                _dbContext.SaveChanges();
            }
            
        }
    }
}
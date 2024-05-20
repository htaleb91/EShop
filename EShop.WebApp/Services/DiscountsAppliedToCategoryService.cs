using EShop.Data;
using EShop.Entities.Domain;
using Microsoft.EntityFrameworkCore;

namespace EShop.Services
{
    public class DiscountsAppliedToCategoryService : IDiscountsAppliedToCategoryService
    {

        private ApplicationDbContext _dbContext;

        public DiscountsAppliedToCategoryService(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IList<DiscountAppliedToCategory>> GetAllDiscountsAppliedToCategorys()
        {
            var context = _dbContext.DiscountsAppliedToCategory;
            return await context.ToListAsync();

        }
        public async Task<DiscountAppliedToCategory> GetDiscountsAppliedToCategory(int id)
        {

            var context = _dbContext.DiscountsAppliedToCategory;
            var discountsAppliedToCategory = context.FirstOrDefault(b => b.Id == id);
            return discountsAppliedToCategory;
        }

        public async Task InsertDiscountsAppliedToCategory(DiscountAppliedToCategory discountsAppliedToCategory)
        {
            var context = _dbContext.DiscountsAppliedToCategory;
            var discountCategory = context.FirstOrDefault(b => b.Id == discountsAppliedToCategory.Id);
            
            if (discountCategory is null)
            {
                discountsAppliedToCategory.CreatedOnUtc = DateTime.UtcNow;
                await context.AddAsync(discountsAppliedToCategory);
                _dbContext.SaveChanges();
            }
        }

        public async Task UpdateDiscountsAppliedToCategory(DiscountAppliedToCategory discountsAppliedToCategory)
        {
            var context = _dbContext.DiscountsAppliedToCategory;
            var discountCategory = context.FirstOrDefault(b => b.Id == discountsAppliedToCategory.Id);
            if (discountCategory is not null)
            {
                discountsAppliedToCategory.UpdatedOnUtc = DateTime.UtcNow;
                context.Update(discountsAppliedToCategory);
                _dbContext.SaveChanges();
            }
        }

        public async Task DeleteDiscountsAppliedToCategory(DiscountAppliedToCategory discountsAppliedToCategory)
        {
            var context = _dbContext.DiscountsAppliedToCategory;
            
            var _discountsAppliedToCategory = context.FirstOrDefault(b => b.Id == discountsAppliedToCategory.Id);
            if (_discountsAppliedToCategory is not null)
            {
                context.Remove(discountsAppliedToCategory);
                _dbContext.SaveChanges();
            }
        }



        public async Task DeleteDiscountsAppliedToCategory(int id)
        {
            var context = _dbContext.DiscountsAppliedToCategory;
            
            var discountsAppliedToCategory = context.FirstOrDefault(b => b.Id == id);
            if (discountsAppliedToCategory is not null)
            {
                context.Remove(discountsAppliedToCategory);
                _dbContext.SaveChanges();
            }
        }

    }
}

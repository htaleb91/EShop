using EShop.Data;
using EShop.Entities.Domain;
using Microsoft.EntityFrameworkCore;

namespace EShop.Services
{
    public class DiscountsAppliedToBrandService : IDiscountsAppliedToBrandService
    {

        private ApplicationDbContext _dbContext;

        public DiscountsAppliedToBrandService(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IList<DiscountAppliedToBrand>> GetAllDiscountsAppliedToBrand()
        {
            var context = _dbContext.DiscountsAppliedToBrand;
            return await context.ToListAsync();

        }
        public async Task<DiscountAppliedToBrand> GetDiscountAppliedToBrand(int id)
        {

            var context = _dbContext.DiscountsAppliedToBrand;
            var discountAppliedToBrand = context.FirstOrDefault(b => b.Id == id);
            return discountAppliedToBrand;
        }

        public async Task InsertDiscountAppliedToBrand(DiscountAppliedToBrand discountAppliedToBrand)
        {
            var context = _dbContext.DiscountsAppliedToBrand;
            var brandDiscount = context.FirstOrDefault(b => b.Id == discountAppliedToBrand.Id);
            if (brandDiscount is null)
            {
                discountAppliedToBrand.CreatedOnUtc = DateTime.UtcNow;
                await context.AddAsync(discountAppliedToBrand);
                _dbContext.SaveChanges();
            }
        }

        public async Task UpdateDiscountAppliedToBrand(DiscountAppliedToBrand discountAppliedToBrand)
        {
            var context = _dbContext.DiscountsAppliedToBrand;
            var brandDiscount = context.FirstOrDefault(b => b.Id == discountAppliedToBrand.Id);
            if (brandDiscount is not null)
            {
                discountAppliedToBrand.UpdatedOnUtc = DateTime.UtcNow;
                await context.AddAsync(discountAppliedToBrand);
                _dbContext.SaveChanges();
            }
        }

        public async Task DeleteDiscountAppliedToBrand(DiscountAppliedToBrand discountAppliedToBrand)
        {
            var context = _dbContext.DiscountsAppliedToBrand;
            
            var _discountAppliedToBrand = context.FirstOrDefault(b => b.Id == discountAppliedToBrand.Id);
            if (_discountAppliedToBrand is not null)
            {
                context.Remove(discountAppliedToBrand);
                _dbContext.SaveChanges();
            }
        }



        public async Task DeleteDiscountAppliedToBrand(int id)
        {
            var context = _dbContext.DiscountsAppliedToBrand;
            
            var discountAppliedToBrand = context.FirstOrDefault(b => b.Id == id);
            if (discountAppliedToBrand is not null)
            {
                context.Remove(discountAppliedToBrand);
                _dbContext.SaveChanges();
            }
        }

    }
}

using EShop.Data;
using EShop.Entities.Domain;
using Microsoft.EntityFrameworkCore;

namespace EShop.Services
{
    public class DiscountsAppliedToProductService : IDiscountsAppliedToProductService
    {

        private ApplicationDbContext _dbContext;

        public DiscountsAppliedToProductService(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IList<DiscountAppliedToProduct>> GetAllDiscountsAppliedToBrand()
        {
            var context = _dbContext.DiscountsAppliedToProduct;
            return await context.ToListAsync();

        }
        public async Task<DiscountAppliedToProduct> GetDiscountAppliedToBrand(int id)
        {

            var context = _dbContext.DiscountsAppliedToProduct;
            var discountAppliedToProduct = context.FirstOrDefault(b => b.Id == id);
            return discountAppliedToProduct;
        }

        public async Task InsertDiscountAppliedToBrand(DiscountAppliedToProduct discountAppliedToProduct)
        {
            _dbContext.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
            var context = _dbContext.DiscountsAppliedToProduct;
            var discountProduct = context.FirstOrDefault(b => b.Id == discountAppliedToProduct.Id);
            if (discountProduct is null)
            {
                discountAppliedToProduct.CreatedOnUtc = DateTime.UtcNow;
                await context.AddAsync(discountAppliedToProduct);
                _dbContext.SaveChanges();
            }

        }

        public async Task UpdateDiscountAppliedToBrand(DiscountAppliedToProduct discountAppliedToProduct)
        {
            var context = _dbContext.DiscountsAppliedToProduct;
            var discountProduct = context.FirstOrDefault(b => b.Id == discountAppliedToProduct.Id);
            if (discountProduct is not null)
            {
                discountAppliedToProduct.UpdatedOnUtc = DateTime.UtcNow;
                context.Update(discountAppliedToProduct);
                _dbContext.SaveChanges();
            }
            
        }

        public async Task DeleteDiscountAppliedToBrand(DiscountAppliedToProduct discountAppliedToProduct)
        {
            var context = _dbContext.DiscountsAppliedToProduct;
            
            var _discountAppliedToProduct = context.FirstOrDefault(b=> b.Id == discountAppliedToProduct.Id);
            if (_discountAppliedToProduct is not null)
            {
                context.Remove(discountAppliedToProduct);
                _dbContext.SaveChanges();
            }

            context.Remove(_discountAppliedToProduct);
            _dbContext.SaveChanges();
        }



        public async Task DeleteDiscountAppliedToBrand(int id)
        {
            var context = _dbContext.DiscountsAppliedToProduct;

            var discountAppliedToProduct = context.FirstOrDefault(b=> b.Id == id);
            if (discountAppliedToProduct is not null)
            {
                context.Remove(discountAppliedToProduct);
                _dbContext.SaveChanges();
            }
        }

    }
}

using EShop.Data;
using EShop.Entities.Domain;
using Microsoft.EntityFrameworkCore;

namespace EShop.Services
{
    public class DiscountService : IDiscountService
    {

        private ApplicationDbContext _dbContext;

        public DiscountService(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IList<Discount>> GetAllDiscounts()
        {
            // _dbContext.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
            var context = _dbContext.Discounts;
            return await context.ToListAsync();

        }
        public async Task<Discount> GetDiscount(int id)
        {

            var context = _dbContext.Discounts;
            var discount = context.Where(b => b.Id== id).FirstOrDefault();
            return discount;
        }

        public async Task InsertDiscount(Discount discount)
        {
            _dbContext.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
            var context = _dbContext.Discounts;
            var _discount = context.Where(b => b.Id == discount.Id).FirstOrDefault();
            if (_discount is null)
            {
                discount.CreatedOnUtc = DateTime.UtcNow;
                await context.AddAsync(discount);
                _dbContext.SaveChanges();
            }
        }

        public async Task UpdateDiscount(Discount discount)
        {
            var context = _dbContext.Discounts;
            var _discount = context.Where(b => b.Id == discount.Id).FirstOrDefault();
            if (_discount is not null)
            {
                discount.UpdatedOnUtc = DateTime.UtcNow;
                context.Update(discount);
                _dbContext.SaveChanges();
            }

        }

        public async Task DeleteDiscount(Discount discount)
        {
            var context = _dbContext.Discounts;
            var query = from b in context
                        where b.Id == discount.Id
                        select b;

            var _discount = query.FirstOrDefault();
            if (_discount is not null)
            {
                context.Remove(discount);
                _dbContext.SaveChanges();
            }
        }



        public async Task DeleteDiscount(int id)
        {
            var context = _dbContext.Discounts;
            var query = from b in context
                        where b.Id==id
                        select b;

            var discount = query.FirstOrDefault();
            if (discount is not null)
            {
                context.Remove(discount);
                _dbContext.SaveChanges();
            }
        }

    }
}

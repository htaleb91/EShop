using EShop.Data;
using EShop.Entities.Domain;
using Microsoft.EntityFrameworkCore;

namespace EShop.Services
{
    public class DiscountUsageHistoryService : IDiscountUsageHistoryService
    {

        private ApplicationDbContext _dbContext;

        public DiscountUsageHistoryService(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IList<DiscountUsageHistory>> GetAllDiscountUsageHistories()
        {
            var context = _dbContext.DiscountsUsageHistory;
            return await context.ToListAsync();

        }
        public async Task<DiscountUsageHistory> GetDiscountUsageHistory(int id)
        {

            var context = _dbContext.DiscountsUsageHistory;
            var discountUsageHistory = context.FirstOrDefault(b => b.Id == id);
            return discountUsageHistory;
        }

        public async Task InsertDiscountUsageHistory(DiscountUsageHistory discountUsageHistory)
        {
            _dbContext.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
            var context = _dbContext.DiscountsUsageHistory;
            var discountHistory = context.FirstOrDefault(b => b.Id == discountUsageHistory.Id);
            if (discountHistory is null )
            {
                discountUsageHistory.CreatedOnUtc = DateTime.UtcNow;
                await context.AddAsync(discountUsageHistory);
                _dbContext.SaveChanges();
            }
        }

        public async Task UpdateDiscountUsageHistory(DiscountUsageHistory discountUsageHistory)
        {
            var context = _dbContext.DiscountsUsageHistory;
            var discountHistory = context.FirstOrDefault(b => b.Id == discountUsageHistory.Id);
            if (discountHistory is not null)
            {
                discountUsageHistory.UpdatedOnUtc = DateTime.UtcNow;
                context.Update(discountUsageHistory);
                _dbContext.SaveChanges();
            }

        }

        public async Task DeleteDiscountUsageHistory(DiscountUsageHistory discountUsageHistory)
        {
            var context = _dbContext.DiscountsUsageHistory;
            
            var _discountUsageHistory = context.FirstOrDefault(b => b.Id == discountUsageHistory.Id);
            if (_discountUsageHistory is not null)
            {
                context.Remove(discountUsageHistory);
                _dbContext.SaveChanges();
            }
            context.Remove(discountUsageHistory);
            _dbContext.SaveChanges();
        }



        public async Task DeleteDiscountUsageHistory(int id)
        {
            var context = _dbContext.DiscountsUsageHistory;
            
            var discountUsageHistory = context.FirstOrDefault(b => b.Id == id);
            if (discountUsageHistory is not null)
            {
                context.Remove(discountUsageHistory);
                _dbContext.SaveChanges();
            }
        }

    }
}

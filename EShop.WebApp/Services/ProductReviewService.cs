using EShop.Data;
using EShop.Entities.Domain;
using Microsoft.EntityFrameworkCore;

namespace EShop.Services
{
    public class ProductReviewService : IProductReviewService
    {

        private ApplicationDbContext _dbContext;

        public ProductReviewService(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IList<ProductReview>> GetAllProductReviews()
        {
            var context = _dbContext.ProductReviews;
            return await context.ToListAsync();

        }
        public async Task<ProductReview> GetProductReview(int id)
        {

            var context = _dbContext.ProductReviews;
            var productReview = context.FirstOrDefault(b => b.Id == id);
            return productReview;
        }

        public async Task InsertProductReview(ProductReview productReview)
        {
            //_dbContext.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
            var context = _dbContext.ProductReviews;
            var pr = context.FirstOrDefault(b => b.Id == productReview.Id);
            if (pr is null)
            {
                productReview.CreatedOnUtc = DateTime.UtcNow;
                await context.AddAsync(productReview);
                _dbContext.SaveChanges();
            }
                
        }

        public async Task UpdateProductReview(ProductReview productReview)
        {
            var context = _dbContext.ProductReviews;
            var pr = context.FirstOrDefault(b => b.Id == productReview.Id);
            if (pr is not null)
            {
                productReview.UpdatedOnUtc = DateTime.UtcNow;
                context.Update(productReview);
                _dbContext.SaveChanges();
            }
            
        }

        public async Task DeleteProductReview(ProductReview productReview)
        {
            var context = _dbContext.ProductReviews;
            var pr = context.FirstOrDefault(b => b.Id == productReview.Id);

            if (pr is not null)
            {
                context.Remove(productReview);
                _dbContext.SaveChanges();
            }
        }



        public async Task DeleteProductReview(int id)
        {
            var context = _dbContext.ProductReviews;
            var pr = context.FirstOrDefault(b => b.Id == id);
                        
            if (pr is not null)
            {
                context.Remove(pr);
                _dbContext.SaveChanges();
            }
        }

    }
}

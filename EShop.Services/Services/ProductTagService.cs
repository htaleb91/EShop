using EShop.Data;
using EShop.Entities.Domain;
using Microsoft.EntityFrameworkCore;

namespace EShop.Services
{
    public class ProductTagService : IProductTagService
    {

        private ApplicationDbContext _dbContext;

        public ProductTagService(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IList<ProductTag>> GetAllProductTags()
        {
            // _dbContext.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
            var context = _dbContext.ProductTags;
            return await context.ToListAsync();

        }
        public async Task<ProductTag> GetProductTag(int id)
        {

            var context = _dbContext.ProductTags;
            var productTag = context.Where(b => b.Id== id).FirstOrDefault();
            return productTag;
        }

        public async Task InsertProductTag(ProductTag productTag)
        {
            //_dbContext.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
            var context = _dbContext.ProductTags;
            var pt = context.Where(b => b.Id == productTag.Id).FirstOrDefault();
            if (pt is null)
            {
                productTag.CreatedOnUtc = DateTime.UtcNow;
                await context.AddAsync(productTag);
                _dbContext.SaveChanges();
            }
                
        }

        public async Task UpdateProductTag(ProductTag productTag)
        {
            var context = _dbContext.ProductTags;
            var pt = context.Where(b => b.Id == productTag.Id).FirstOrDefault();
            if (pt is not null)
            {
                productTag.UpdatedOnUtc = DateTime.UtcNow;
                context.Update(productTag);
                _dbContext.SaveChanges();
            }
            
        }

        public async Task DeleteProductTag(ProductTag productTag)
        {
            var context = _dbContext.ProductTags;
            var pt = (from b in context
                      where b.Id == productTag.Id
                      select b).FirstOrDefault();

            if (pt is not null)
            {
                context.Remove(productTag);
                _dbContext.SaveChanges();
            }

        }



        public async Task DeleteProductTag(int id)
        {
            var context = _dbContext.ProductTags;
            var pt = (from b in context
                        where b.Id == id
                        select b).FirstOrDefault();

            if (pt is not null)
            {
                context.Remove(pt);
                _dbContext.SaveChanges();
            }
        }

    }
}

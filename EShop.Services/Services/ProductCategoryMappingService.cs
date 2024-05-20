using EShop.Data;
using EShop.Entities.Domain;
using Microsoft.EntityFrameworkCore;

namespace EShop.Services
{
    public class ProductCategoryMappingService : IProductCategoryMappingService
    {

        private ApplicationDbContext _dbContext;

        public ProductCategoryMappingService(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IList<ProductCategoryMapping>> GetAllProductCategoryMappings()
        {
            // _dbContext.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
            var context = _dbContext.ProductCategoryMappings;
            return await context.ToListAsync();

        }
        public async Task<ProductCategoryMapping> GetProductCategoryMapping(int id)
        {

            var context = _dbContext.ProductCategoryMappings;
            var productCategoryMapping = context.Where(b => b.Id== id).FirstOrDefault();
            return productCategoryMapping;
        }

        public async Task InsertProductCategoryMapping(ProductCategoryMapping productCategoryMapping)
        {
            //_dbContext.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
            var context = _dbContext.ProductCategoryMappings;
            var pcm = context.Where(b => b.Id == productCategoryMapping.Id).FirstOrDefault();
            if (pcm is null)
            {
                 productCategoryMapping.CreatedOnUtc = DateTime.UtcNow;
                await context.AddAsync(productCategoryMapping);
                _dbContext.SaveChanges();
            }
                
        }

        public async Task UpdateProductCategoryMapping(ProductCategoryMapping productCategoryMapping)
        {
            var context = _dbContext.ProductCategoryMappings;
            var pcm = context.Where(b => b.Id == productCategoryMapping.Id).FirstOrDefault();
            if (pcm is not null)
            {
                productCategoryMapping.UpdatedOnUtc = DateTime.UtcNow;
                context.Update(productCategoryMapping);
                _dbContext.SaveChanges();
            }
            
        }

        public async Task DeleteProductCategoryMapping(ProductCategoryMapping productCategoryMapping)
        {
            var context = _dbContext.ProductCategoryMappings;
            var pcm = (from b in context
                       where b.Id == productCategoryMapping.Id
                       select b).FirstOrDefault();


            if (pcm is not null)
            {
                context.Remove(productCategoryMapping);
                _dbContext.SaveChanges();
            }
        }



        public async Task DeleteProductCategoryMapping(int id)
        {
            var context = _dbContext.ProductCategoryMappings;
            var pcm = (from b in context
                        where b.Id == id
                        select b).FirstOrDefault();

            
            if (pcm is not null)
            {
                context.Remove(pcm);
                _dbContext.SaveChanges();
            }
        }

    }
}

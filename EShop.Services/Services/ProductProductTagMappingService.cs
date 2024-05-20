using EShop.Data;
using EShop.Entities.Domain;
using Microsoft.EntityFrameworkCore;

namespace EShop.Services
{
    public class ProductProductTagMappingService : IProductProductTagMappingService
    {

        private ApplicationDbContext _dbContext;

        public ProductProductTagMappingService(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IList<ProductProductTagMapping>> GetAllProductProductTagMappings()
        {
            // _dbContext.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
            var context = _dbContext.ProductProductTagMappings;
            return await context.ToListAsync();

        }
        public async Task<ProductProductTagMapping> GetProductProductTagMapping(int id)
        {

            var context = _dbContext.ProductProductTagMappings;
            var productProductTagMapping = context.Where(b => b.Id== id).FirstOrDefault();
            return productProductTagMapping;
        }

        public async Task InsertProductProductTagMapping(ProductProductTagMapping productProductTagMapping)
        {
            //_dbContext.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
            var context = _dbContext.ProductProductTagMappings;
            var pptm = context.Where(b => b.Id == productProductTagMapping.Id).FirstOrDefault();
            if (pptm is null)
            {
                productProductTagMapping.CreatedOnUtc = DateTime.UtcNow;
                await context.AddAsync(productProductTagMapping);
                _dbContext.SaveChanges();
            }
                
        }

        public async Task UpdateProductProductTagMapping(ProductProductTagMapping productProductTagMapping)
        {
            var context = _dbContext.ProductProductTagMappings;
            var pptm = context.Where(b => b.Id == productProductTagMapping.Id).FirstOrDefault();
            if (pptm is not null)
            {
                productProductTagMapping.UpdatedOnUtc = DateTime.UtcNow;
                context.Update(productProductTagMapping);
                _dbContext.SaveChanges();
            }
            
        }

        public async Task DeleteProductProductTagMapping(ProductProductTagMapping productProductTagMapping)
        {
            var context = _dbContext.ProductProductTagMappings;
            var pptm = (from b in context
                        where b.Id == productProductTagMapping.Id
                        select b).FirstOrDefault();


            if (pptm is not null)
            {
                context.Remove(productProductTagMapping);
                _dbContext.SaveChanges();
            }
        }



        public async Task DeleteProductProductTagMapping(int id)
        {
            var context = _dbContext.ProductProductTagMappings;
            var pptm = (from b in context
                        where b.Id == id
                        select b).FirstOrDefault();

            
            if (pptm is not null)
            {
                context.Remove(pptm);
                _dbContext.SaveChanges();
            }
        }

    }
}

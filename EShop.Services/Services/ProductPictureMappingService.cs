using EShop.Data;
using EShop.Entities.Domain;
using Microsoft.EntityFrameworkCore;

namespace EShop.Services
{
    public class ProductPictureMappingService : IProductPictureMappingService
    {

        private ApplicationDbContext _dbContext;

        public ProductPictureMappingService(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IList<ProductPictureMapping>> GetAllProductPictureMappings()
        {
            // _dbContext.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
            var context = _dbContext.ProductPictureMappings;
            return await context.ToListAsync();

        }
        public async Task<ProductPictureMapping> GetProductPictureMapping(int id)
        {

            var context = _dbContext.ProductPictureMappings;
            var productPictureMapping = context.Where(b => b.Id== id).FirstOrDefault();
            return productPictureMapping;
        }

        public async Task InsertProductPictureMapping(ProductPictureMapping productPictureMapping)
        {
            //_dbContext.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
            var context = _dbContext.ProductPictureMappings;
            var ppm = context.Where(b => b.Id == productPictureMapping.Id).FirstOrDefault();
            if (ppm is null)
            {
                productPictureMapping.CreatedOnUtc = DateTime.UtcNow;
                await context.AddAsync(productPictureMapping);
                _dbContext.SaveChanges();
            }
               
        }

        public async Task UpdateProductPictureMapping(ProductPictureMapping productPictureMapping)
        {
            var context = _dbContext.ProductPictureMappings;
            var ppm = context.Where(b => b.Id == productPictureMapping.Id).FirstOrDefault();
            if (ppm is not null)
            {
                productPictureMapping.UpdatedOnUtc = DateTime.UtcNow;
                context.Update(productPictureMapping);
                _dbContext.SaveChanges();
            }
            
        }

        public async Task DeleteProductPictureMapping(ProductPictureMapping productPictureMapping)
        {
            var context = _dbContext.ProductPictureMappings;
            var ppm = (from b in context
                       where b.Id == productPictureMapping.Id
                       select b).FirstOrDefault();


            if (ppm is not null)
            {
                context.Remove(productPictureMapping);
                _dbContext.SaveChanges();
            }
        }



        public async Task DeleteProductPictureMapping(int id)
        {
            var context = _dbContext.ProductPictureMappings;
            var ppm = (from b in context
                        where b.Id == id
                        select b).FirstOrDefault();

            
            if (ppm is not null)
            {
                context.Remove(ppm);
                _dbContext.SaveChanges();
            }
        }

    }
}

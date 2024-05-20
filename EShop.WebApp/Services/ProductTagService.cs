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
            var context = _dbContext.ProductTags;
            return await context.ToListAsync();

        }
        public async Task<ProductTag> GetProductTag(int id)
        {

            var context = _dbContext.ProductTags;
            var productTag = context.FirstOrDefault(b => b.Id == id);
            return productTag;
        }

        public async Task InsertProductTag(ProductTag productTag)
        {
            var context = _dbContext.ProductTags;
            var pt = context.FirstOrDefault(b => b.Id == productTag.Id);
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
            var pt = context.FirstOrDefault(b => b.Id == productTag.Id);
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
            var pt = context.FirstOrDefault(b => b.Id == productTag.Id);

            if (pt is not null)
            {
                context.Remove(productTag);
                _dbContext.SaveChanges();
            }

        }



        public async Task DeleteProductTag(int id)
        {
            var context = _dbContext.ProductTags;
            var pt = context.FirstOrDefault(b => b.Id == id);

            if (pt is not null)
            {
                context.Remove(pt);
                _dbContext.SaveChanges();
            }
        }

    }
}

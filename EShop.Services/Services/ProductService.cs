using EShop.Data;
using EShop.Entities.Domain;
using Microsoft.EntityFrameworkCore;

namespace EShop.Services
{
    public class ProductService : IProductService
    {
        private ApplicationDbContext _dbContext;

        public ProductService(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IList<Product>> GetAllProducts()
        {
            // _dbContext.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
            var context = _dbContext.Products.Include("Shipment").Include("Brand");
            return await context.ToListAsync();

        }
        public async Task<Product> GetProduct(int id)
        {

            var context = _dbContext.Products;
            var product = context.Where(b => b.Id.Equals(id.ToString()))
                                 .Include("Shipment").Include("Brand").FirstOrDefault();
            return product;
        }

        public async Task InsertProduct(Product product)
        {
           // _dbContext.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
            var context = _dbContext.Products;
            var p = context.Where(b => b.Id == product.Id).FirstOrDefault();
            if (p is null)
            {
                product.CreatedOnUtc = DateTime.UtcNow;
                await context.AddAsync(product);
                _dbContext.SaveChanges();
            }
                
        }

        public async Task UpdateProduct(Product product)
        {
            var context = _dbContext.Products;
            var p = context.Where(b => b.Id == product.Id).FirstOrDefault();
            if (p is not null)
            {
                product.UpdatedOnUtc = DateTime.UtcNow;
                context.Update(product);
                _dbContext.SaveChanges();
            }


        }

        public async Task DeleteProduct(Product product)
        {
            var context = _dbContext.Products;
            var p = (from b in context
                     where b.Id == product.Id
                     select b).FirstOrDefault();

            if (p is not null)
            {
                product.Deleted = true;
                context.Update(product);
                _dbContext.SaveChanges();
            }
        }



        public async Task DeleteProduct(int id)
        {
            var context = _dbContext.Products;
            var p = (from b in context
                        where b.Id == id
                        select b).FirstOrDefault();

            if (p is not null)
            {
                p.Deleted = true;
                context.Update(p);
                _dbContext.SaveChanges();
            }
        }

    }
}

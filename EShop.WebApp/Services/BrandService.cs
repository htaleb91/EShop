using EShop.Data;
using EShop.Entities.Domain;
using Microsoft.EntityFrameworkCore;
using System.Drawing.Drawing2D;

namespace EShop.Services
{
    public class BrandService : IBrandService
    {

        private ApplicationDbContext _dbContext;

        public BrandService(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IList<Brand>> GetAllBrands()
        {
            var context = _dbContext.Brands;
            return await context.ToListAsync();

        }
        public async Task<Brand> GetBrand(int id)
        {

            var context = _dbContext.Brands;
            var brand = context.FirstOrDefault(b => b.Id == id);
            return brand;
        }

        public async Task InsertBrand(Brand brand)
        {
            var context = _dbContext.Brands;
            var _brand = context.FirstOrDefault(b => b.Id == brand.Id);
            if (_brand is null)
            {
                brand.CreatedOnUtc = DateTime.UtcNow;
                await context.AddAsync(brand);
                _dbContext.SaveChanges();
            }
                
        }

        public async Task UpdateBrand(Brand brand)
        {
            var context = _dbContext.Brands;
            var _brand = context.FirstOrDefault(b => b.Id == brand.Id);
            if (_brand is not null)
            {
                brand.UpdatedOnUtc = DateTime.UtcNow;
                context.Update(brand);
                _dbContext.SaveChanges();

            }
        }

        public async Task DeleteBrand(Brand brand)
        {
            var context = _dbContext.Brands;
           
            var _brand = context.FirstOrDefault(b => b.Id == brand.Id);
            if (_brand is not null)
            {
                brand.Deleted = true;
                context.Update(brand);
                _dbContext.SaveChanges();
            }
        }



        public async Task DeleteBrand(int id)
        {
            var context = _dbContext.Brands;
            
            var _brand = context.FirstOrDefault(b=>b.Id==id);
            if (_brand is not null)
            {
                _brand.Deleted = true;
                context.Update(_brand);
                _dbContext.SaveChanges();
            }
        }

    }
}

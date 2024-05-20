using EShop.Data;
using EShop.Entities.Domain;
using Microsoft.EntityFrameworkCore;

namespace EShop.Services
{
    public class PictureService : IPictureService
    {

        private ApplicationDbContext _dbContext;

        public PictureService(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IList<Picture>> GetAllPictures()
        {
            var context = _dbContext.Pictures;
            return await context.ToListAsync();

        }
        public async Task<Picture> GetPicture(int? id)
        {
            if (id is not null && id > 0)
            {

                var context = _dbContext.Pictures;
                var picture = context.FirstOrDefault(b => b.Id == id);
                return picture;
            }
            return new Picture();
        }

        public async Task InsertPicture(Picture picture)
        {
            var context = _dbContext.Pictures;
            var pic = context.FirstOrDefault(b => b.Id == picture.Id);
            if (pic is null)
            {
                picture.CreatedOnUtc = DateTime.UtcNow;
                await context.AddAsync(picture);
                _dbContext.SaveChanges();
            }
                
        }

        public async Task UpdatePicture(Picture picture)
        {
            var context = _dbContext.Pictures;
            var pic = context.FirstOrDefault(b => b.Id == picture.Id);
            if (pic is not null)
            {
                picture.UpdatedOnUtc = DateTime.UtcNow;
                context.Update(picture);
                _dbContext.SaveChanges();
            }
            
        }

        public async Task DeletePicture(Picture picture)
        {
            var context = _dbContext.Pictures;
            var pic = context.FirstOrDefault(b => b.Id == picture.Id);

            if (pic is not null)
            {
                context.Remove(picture);
                _dbContext.SaveChanges();
            }
        }



        public async Task DeletePicture(int id)
        {
            var context = _dbContext.Pictures;
            var picture = context.FirstOrDefault(b => b.Id == id);

            
            if (picture is not null)
            {
                context.Remove(picture);
                _dbContext.SaveChanges();
            }
        }

    }
}

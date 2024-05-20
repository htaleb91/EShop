using EShop.Data;
using EShop.Entities.Domain;
using System.Drawing.Drawing2D;

namespace EShop.Services
{
    public class LocalizedContentService : ILocalizedContentService
    {
        private ApplicationDbContext _dbContext;
        public LocalizedContentService(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task DeleteLocalizedContent(int id)
        {
            var context = _dbContext.LocalizedContent;
            var _localizedContent = context.FirstOrDefault(b=>b.Id == id);

            if (_localizedContent is not null)
            {
                context.Remove(_localizedContent);
                _dbContext.SaveChanges();
            }
        }

        public async Task DeleteLocalizedContent(LocalizedContent localizedContent)
        {
             var context = _dbContext.LocalizedContent;
            var _localizedContent = context.FirstOrDefault(b => b.Id == localizedContent.Id);

            if (_localizedContent is not null)
            {
                context.Remove(localizedContent);
                _dbContext.SaveChanges();
            }
        }

        public async Task<IList<LocalizedContent>> GetAllLocalizedContents()
        {
            var context = _dbContext.LocalizedContent;
            return await context.ToListAsync();
        }

        public async Task<LocalizedContent> GetLocalizedContent(int id)
        {
            var context = _dbContext.LocalizedContent;
            var localeContent = context.FirstOrDefault(b => b.Id == id);
            return localeContent;
        }

        public async Task InsertLocalizedContent(LocalizedContent localizedContent)
        {
            var context = _dbContext.LocalizedContent;
            var _localizedContent = context.FirstOrDefault(b => b.Id == localizedContent.Id);
            if (_localizedContent is null)
            {
                localizedContent.CreatedOnUtc = DateTime.UtcNow;
                await context.AddAsync(localizedContent);
                _dbContext.SaveChanges();
            }
        }

        public async Task UpdateLocalizedContent(LocalizedContent localizedContent)
        {
            var context = _dbContext.LocalizedContent;
            var _localeContent = context.FirstOrDefault(b => b.Id == localizedContent.Id);
            if (_localeContent is not null)
            {
                localizedContent.UpdatedOnUtc = DateTime.UtcNow;
                context.Update(localizedContent);
                _dbContext.SaveChanges();

            }
        }
    }
}

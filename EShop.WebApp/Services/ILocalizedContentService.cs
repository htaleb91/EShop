using EShop.Entities.Domain;

namespace EShop.Services
{
    public interface ILocalizedContentService
    {
        Task DeleteLocalizedContent(int id);
        Task DeleteLocalizedContent(LocalizedContent localizedContent);
        Task<IList<LocalizedContent>> GetAllLocalizedContents();
        Task<LocalizedContent> GetLocalizedContent(int id);
        Task InsertLocalizedContent(LocalizedContent localizedContent);
        Task UpdateLocalizedContent(LocalizedContent localizedContent);
    }
}

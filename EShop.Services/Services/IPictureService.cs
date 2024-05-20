using EShop.Entities.Domain;

namespace EShop.Services
{
    public interface IPictureService
    {
        Task DeletePicture(int id);
        Task DeletePicture(Picture Picture);
        Task<IList<Picture>> GetAllPictures();
        Task<Picture> GetPicture(int? id);
        Task InsertPicture(Picture Picture);
        Task UpdatePicture(Picture Picture);
    }
}
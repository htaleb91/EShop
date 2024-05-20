using EShop.Entities.Domain;

namespace EShop.Services
{
    public interface IBrandService
    {
        Task DeleteBrand(int id);
        Task DeleteBrand(Brand Brand);
        Task<IList<Brand>> GetAllBrands();
        Task<Brand> GetBrand(int id);
        Task InsertBrand(Brand Brand);
        Task UpdateBrand(Brand Brand);
    }
}

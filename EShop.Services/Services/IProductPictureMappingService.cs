using EShop.Entities.Domain;

namespace EShop.Services
{
    public interface IProductPictureMappingService
    {
        Task DeleteProductPictureMapping(int id);
        Task DeleteProductPictureMapping(ProductPictureMapping ProductPictureMapping);
        Task<IList<ProductPictureMapping>> GetAllProductPictureMappings();
        Task<ProductPictureMapping> GetProductPictureMapping(int id);
        Task InsertProductPictureMapping(ProductPictureMapping ProductPictureMapping);
        Task UpdateProductPictureMapping(ProductPictureMapping ProductPictureMapping);
    }
}
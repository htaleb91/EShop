using EShop.Entities.Domain;

namespace EShop.Services
{
    public interface IProductCategoryMappingService
    {
        Task DeleteProductCategoryMapping(int id);
        Task DeleteProductCategoryMapping(ProductCategoryMapping ProductCategoryMapping);
        Task<IList<ProductCategoryMapping>> GetAllProductCategoryMappings();
        Task<ProductCategoryMapping> GetProductCategoryMapping(int id);
        Task InsertProductCategoryMapping(ProductCategoryMapping ProductCategoryMapping);
        Task UpdateProductCategoryMapping(ProductCategoryMapping ProductCategoryMapping);
    }
}
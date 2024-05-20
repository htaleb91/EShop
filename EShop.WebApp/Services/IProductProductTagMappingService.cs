using EShop.Entities.Domain;

namespace EShop.Services
{
    public interface IProductProductTagMappingService
    {
        Task DeleteProductProductTagMapping(int id);
        Task DeleteProductProductTagMapping(ProductProductTagMapping ProductProductTagMapping);
        Task<IList<ProductProductTagMapping>> GetAllProductProductTagMappings();
        Task<ProductProductTagMapping> GetProductProductTagMapping(int id);
        Task InsertProductProductTagMapping(ProductProductTagMapping ProductProductTagMapping);
        Task UpdateProductProductTagMapping(ProductProductTagMapping ProductProductTagMapping);
    }
}
using EShop.Entities.Domain;

namespace EShop.Services
{
    public interface IProductTagService
    {
        Task DeleteProductTag(int id);
        Task DeleteProductTag(ProductTag ProductTag);
        Task<IList<ProductTag>> GetAllProductTags();
        Task<ProductTag> GetProductTag(int id);
        Task InsertProductTag(ProductTag ProductTag);
        Task UpdateProductTag(ProductTag ProductTag);
    }
}
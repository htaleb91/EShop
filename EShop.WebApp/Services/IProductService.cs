using EShop.Entities.Domain;

namespace EShop.Services
{
    public interface IProductService
    {
        Task DeleteProduct(int id);
        Task DeleteProduct(Product Product);
        Task<IList<Product>> GetAllProducts();
        Task<Product> GetProduct(int id);
        Task InsertProduct(Product Product);
        Task UpdateProduct(Product Product);
    }
}
using EShop.Entities.Domain;

namespace EShop.Services
{
    public interface IProductReviewService
    {
        Task DeleteProductReview(int id);
        Task DeleteProductReview(ProductReview ProductReview);
        Task<IList<ProductReview>> GetAllProductReviews();
        Task<ProductReview> GetProductReview(int id);
        Task InsertProductReview(ProductReview ProductReview);
        Task UpdateProductReview(ProductReview ProductReview);
    }
}
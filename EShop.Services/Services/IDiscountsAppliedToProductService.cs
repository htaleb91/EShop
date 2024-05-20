using EShop.Entities.Domain;

namespace EShop.Services
{
    public interface IDiscountsAppliedToProductService
    {
        Task DeleteDiscountAppliedToBrand(DiscountAppliedToProduct DiscountAppliedToProduct);
        Task DeleteDiscountAppliedToBrand(int id);
        Task<IList<DiscountAppliedToProduct>> GetAllDiscountsAppliedToBrand();
        Task<DiscountAppliedToProduct> GetDiscountAppliedToBrand(int id);
        Task InsertDiscountAppliedToBrand(DiscountAppliedToProduct DiscountAppliedToProduct);
        Task UpdateDiscountAppliedToBrand(DiscountAppliedToProduct DiscountAppliedToProduct);
    }
}
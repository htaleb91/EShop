using EShop.Entities.Domain;

namespace EShop.Services
{
    public interface IDiscountsAppliedToBrandService
    {
        Task DeleteDiscountAppliedToBrand(DiscountAppliedToBrand DiscountAppliedToBrand);
        Task DeleteDiscountAppliedToBrand(int id);
        Task<IList<DiscountAppliedToBrand>> GetAllDiscountsAppliedToBrand();
        Task<DiscountAppliedToBrand> GetDiscountAppliedToBrand(int id);
        Task InsertDiscountAppliedToBrand(DiscountAppliedToBrand DiscountAppliedToBrand);
        Task UpdateDiscountAppliedToBrand(DiscountAppliedToBrand DiscountAppliedToBrand);
    }
}
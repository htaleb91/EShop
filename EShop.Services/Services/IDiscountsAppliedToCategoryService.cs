using EShop.Entities.Domain;

namespace EShop.Services
{
    public interface IDiscountsAppliedToCategoryService
    {
        Task DeleteDiscountsAppliedToCategory(DiscountAppliedToCategory DiscountsAppliedToCategory);
        Task DeleteDiscountsAppliedToCategory(int id);
        Task<IList<DiscountAppliedToCategory>> GetAllDiscountsAppliedToCategorys();
        Task<DiscountAppliedToCategory> GetDiscountsAppliedToCategory(int id);
        Task InsertDiscountsAppliedToCategory(DiscountAppliedToCategory DiscountsAppliedToCategory);
        Task UpdateDiscountsAppliedToCategory(DiscountAppliedToCategory DiscountsAppliedToCategory);
    }
}
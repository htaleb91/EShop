using EShop.Entities.Domain;

namespace EShop.Services
{
    public interface IDiscountUsageHistoryService
    {
        Task DeleteDiscountUsageHistory(DiscountUsageHistory DiscountUsageHistory);
        Task DeleteDiscountUsageHistory(int id);
        Task<IList<DiscountUsageHistory>> GetAllDiscountUsageHistories();
        Task<DiscountUsageHistory> GetDiscountUsageHistory(int id);
        Task InsertDiscountUsageHistory(DiscountUsageHistory DiscountUsageHistory);
        Task UpdateDiscountUsageHistory(DiscountUsageHistory DiscountUsageHistory);
    }
}
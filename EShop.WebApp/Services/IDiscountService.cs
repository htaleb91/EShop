using EShop.Entities.Domain;

namespace EShop.Services
{
    public interface IDiscountService
    {
        Task DeleteDiscount(Discount Discount);
        Task DeleteDiscount(int id);
        Task<IList<Discount>> GetAllDiscounts();
        Task<Discount> GetDiscount(int id);
        Task InsertDiscount(Discount Discount);
        Task UpdateDiscount(Discount Discount);
    }
}
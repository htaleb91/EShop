using EShop.Entities.Domain;

namespace EShop.Services
{
    public interface IOrderService
    {
        Task DeleteOrder(int id);
        Task DeleteOrder(Order Order);
        Task<IList<Order>> GetAllOrders();
        Task<Order> GetOrder(int id);
        Task InsertOrder(Order Order);
        Task UpdateOrder(Order Order);
    }
}
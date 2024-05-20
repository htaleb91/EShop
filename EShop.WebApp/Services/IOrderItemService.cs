using EShop.Entities.Domain;

namespace EShop.Services
{
    public interface IOrderItemService
    {
        Task DeleteOrderItem(int id);
        Task DeleteOrderItem(OrderItem OrderItem);
        Task<IList<OrderItem>> GetAllOrderItems();
        Task<OrderItem> GetOrderItem(int id);
        Task InsertOrderItem(OrderItem OrderItem);
        Task UpdateOrderItem(OrderItem OrderItem);
    }
}
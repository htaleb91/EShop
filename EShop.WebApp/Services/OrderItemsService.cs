using EShop.Data;
using EShop.Entities.Domain;
using Microsoft.EntityFrameworkCore;

namespace EShop.Services
{
    public class OrderItemService : IOrderItemService
    {

        private ApplicationDbContext _dbContext;

        public OrderItemService(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IList<OrderItem>> GetAllOrderItems()
        {
            var context = _dbContext.OrderItems;
            return await context.ToListAsync();

        }
        public async Task<OrderItem> GetOrderItem(int id)
        {

            var context = _dbContext.OrderItems;
            var orderItem = context.FirstOrDefault(b => b.Id== id);
            return orderItem;
        }

        public async Task InsertOrderItem(OrderItem orderItem)
        {
            //_dbContext.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
            var context = _dbContext.OrderItems;
            var _orderItem = context.FirstOrDefault(b => b.Id == orderItem.Id);
            if (_orderItem is null)
            {
                orderItem.CreatedOnUtc = DateTime.UtcNow;
                await context.AddAsync(orderItem);
                _dbContext.SaveChanges();
            }
        }

        public async Task UpdateOrderItem(OrderItem orderItem)
        {
            var context = _dbContext.OrderItems;
            var _orderItem = context.FirstOrDefault(b => b.Id == orderItem.Id);
            if (_orderItem is not null)
            {
                orderItem.UpdatedOnUtc = DateTime.UtcNow;
                context.Update(orderItem);
                _dbContext.SaveChanges();
            }
            
        }

        public async Task DeleteOrderItem(OrderItem orderItem)
        {
            var context = _dbContext.OrderItems;
            var _orderItem = context.FirstOrDefault(b => b.Id == orderItem.Id);
            
            if (_orderItem is not null)
            {
                context.Remove(orderItem);
                _dbContext.SaveChanges();
            }
        }



        public async Task DeleteOrderItem(int id)
        {
            var context = _dbContext.OrderItems;
            var orderItem =context.FirstOrDefault(b => b.Id == id);

            if (orderItem is not null)
            {
                context.Remove(orderItem);
                _dbContext.SaveChanges();
            }
        }

    }
}

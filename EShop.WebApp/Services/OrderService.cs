using EShop.Data;
using EShop.Entities.Domain;
using Microsoft.EntityFrameworkCore;

namespace EShop.Services
{
    public class OrderService : IOrderService
    {

        private ApplicationDbContext _dbContext;

        public OrderService(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IList<Order>> GetAllOrders()
        {
            var context = _dbContext.Orders;
            return await context.ToListAsync();

        }
        public async Task<Order> GetOrder(int id)
        {

            var context = _dbContext.Orders;
            var order = context.FirstOrDefault(b => b.Id == id);
            return order;
        }

        public async Task InsertOrder(Order order)
        {
            var context = _dbContext.Orders;
            var _order = context.FirstOrDefault(b => b.Id == order.Id);
            if (_order is null)
            {
                order.CreatedOnUtc = DateTime.UtcNow;
                await context.AddAsync(order);
                _dbContext.SaveChanges();
            }
                
        }

        public async Task UpdateOrder(Order order)
        {
            var context = _dbContext.Orders;
            var _order = context.FirstOrDefault(b => b.Id == order.Id);
            if (_order is not null)
            {
                order.UpdatedOnUtc = DateTime.UtcNow;
                context.Update(order);
                _dbContext.SaveChanges();
            }
            
        }

        public async Task DeleteOrder(Order order)
        {
            var context = _dbContext.Orders;
            var _order = context.FirstOrDefault(b => b.Id == order.Id);

            if (_order is not null)
            {
                order.Deleted = true;
                context.Update(order);
                _dbContext.SaveChanges();
            }
        }



        public async Task DeleteOrder(int id)
        {
            var context = _dbContext.Orders;
            var order = context.FirstOrDefault(b => b.Id == id);
            
            if (order is not null)
            {
                order.Deleted = true;
                context.Update(order);
                _dbContext.SaveChanges();
            }
        }

    }
}

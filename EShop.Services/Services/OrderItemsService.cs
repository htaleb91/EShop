﻿using EShop.Data;
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
            // _dbContext.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
            var context = _dbContext.OrderItems;
            return await context.ToListAsync();

        }
        public async Task<OrderItem> GetOrderItem(int id)
        {

            var context = _dbContext.OrderItems;
            var orderItem = context.Where(b => b.Id== id).FirstOrDefault();
            return orderItem;
        }

        public async Task InsertOrderItem(OrderItem orderItem)
        {
            //_dbContext.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
            var context = _dbContext.OrderItems;
            var _orderItem = context.Where(b => b.Id == orderItem.Id).FirstOrDefault();
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
            var _orderItem = context.Where(b => b.Id == orderItem.Id).FirstOrDefault();
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
            var _orderItem = (from b in context
                        where b.Id == orderItem.Id
                        select b).FirstOrDefault();

            
            if (_orderItem is not null)
            {
                context.Remove(orderItem);
                _dbContext.SaveChanges();
            }
        }



        public async Task DeleteOrderItem(int id)
        {
            var context = _dbContext.OrderItems;
            var orderItem =( from b in context
                        where b.Id == id
                        select b).FirstOrDefault();

            
            if (orderItem is not null)
            {
                context.Remove(orderItem);
                _dbContext.SaveChanges();
            }
        }

    }
}

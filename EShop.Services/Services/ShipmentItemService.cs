using EShop.Data;
using EShop.Entities.Domain;
using Microsoft.EntityFrameworkCore;

namespace EShop.Services
{
    public class ShipmentItemService : IShipmentItemService
    {

        private ApplicationDbContext _dbContext;

        public ShipmentItemService(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IList<ShipmentItem>> GetAllShipmentItems()
        {
            // _dbContext.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
            var context = _dbContext.ShipmentItems;
            return await context.ToListAsync();

        }
        public async Task<ShipmentItem> GetShipmentItem(int id)
        {

            var context = _dbContext.ShipmentItems;
            var shipmentItem = context.Where(b => b.Id== id).FirstOrDefault();
            return shipmentItem;
        }

        public async Task InsertShipmentItem(ShipmentItem shipmentItem)
        {
            //_dbContext.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
            var context = _dbContext.ShipmentItems;
            var si = context.Where(b => b.Id == shipmentItem.Id).FirstOrDefault();
            if (si is null)
            {
                shipmentItem.CreatedOnUtc = DateTime.UtcNow;
                await context.AddAsync(shipmentItem);
                _dbContext.SaveChanges();
            }
                
        }

        public async Task UpdateShipmentItem(ShipmentItem shipmentItem)
        {
            var context = _dbContext.ShipmentItems;
            var si = context.Where(b => b.Id == shipmentItem.Id).FirstOrDefault();
            if (si is not null)
            {
                shipmentItem.UpdatedOnUtc = DateTime.UtcNow;
                context.Update(shipmentItem);
                _dbContext.SaveChanges();
            }
            
        }

        public async Task DeleteShipmentItem(ShipmentItem shipmentItem)
        {
            var context = _dbContext.ShipmentItems;
            var si = (from b in context
                      where b.Id == shipmentItem.Id
                      select b).FirstOrDefault();


            if (si is not null)
            {
                context.Remove(shipmentItem);
                _dbContext.SaveChanges();
            }
        }



        public async Task DeleteShipmentItem(int id)
        {
            var context = _dbContext.ShipmentItems;
            var si = (from b in context
                        where b.Id == id
                        select b).FirstOrDefault();

            
            if (si is not null)
            {
                context.Remove(si);
                _dbContext.SaveChanges();
            }
        }

    }
}

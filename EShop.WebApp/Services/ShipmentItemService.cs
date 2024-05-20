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
            var context = _dbContext.ShipmentItems;
            return await context.ToListAsync();

        }
        public async Task<ShipmentItem> GetShipmentItem(int id)
        {

            var context = _dbContext.ShipmentItems;
            var shipmentItem = context.FirstOrDefault(b => b.Id== id);
            return shipmentItem;
        }

        public async Task InsertShipmentItem(ShipmentItem shipmentItem)
        {
            var context = _dbContext.ShipmentItems;
            var si = context.FirstOrDefault(b => b.Id == shipmentItem.Id);
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
            var si = context.FirstOrDefault(b => b.Id == shipmentItem.Id);
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
            var si = context.FirstOrDefault(b => b.Id == shipmentItem.Id);

            if (si is not null)
            {
                context.Remove(shipmentItem);
                _dbContext.SaveChanges();
            }
        }



        public async Task DeleteShipmentItem(int id)
        {
            var context = _dbContext.ShipmentItems;
            var si = context.FirstOrDefault(b => b.Id == id);
                        
            if (si is not null)
            {
                context.Remove(si);
                _dbContext.SaveChanges();
            }
        }

    }
}

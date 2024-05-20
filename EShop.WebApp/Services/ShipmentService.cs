using EShop.Data;
using EShop.Entities.Domain;
using Microsoft.EntityFrameworkCore;

namespace EShop.Services
{
    public class ShipmentService : IShipmentService
    {

        private ApplicationDbContext _dbContext;

        public ShipmentService(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IList<Shipment>> GetAllShipments()
        {
            var context = _dbContext.Shipments;
            return await context.ToListAsync();

        }
        public async Task<Shipment> GetShipment(int id)
        {

            var context = _dbContext.Shipments;
            var shipment = context.FirstOrDefault(b => b.Id == id);
            return shipment;
        }

        public async Task InsertShipment(Shipment shipment)
        {
            var context = _dbContext.Shipments;
            var sh = context.FirstOrDefault(b => b.Id == shipment.Id);
            if (sh is null )
            {
                shipment.CreatedOnUtc = DateTime.UtcNow;
                await context.AddAsync(shipment);
                _dbContext.SaveChanges();

            }
        }

        public async Task UpdateShipment(Shipment shipment)
        {
            var context = _dbContext.Shipments;
            var sh = context.FirstOrDefault(b => b.Id == shipment.Id);
            if(sh is not null)
            {
                shipment.UpdatedOnUtc = DateTime.UtcNow;
                context.Update(shipment);
                _dbContext.SaveChanges();
                
            }
        }

        public async Task DeleteShipment(Shipment shipment)
        {
            var context = _dbContext.Shipments;
            var s = context.FirstOrDefault(b => b.Id == shipment.Id);

            if (s is not null)
            {
                context.Remove(shipment);
                _dbContext.SaveChanges();
            }
            
        }



        public async Task DeleteShipment(int id)
        {
            var context = _dbContext.Shipments;
            var s = context.FirstOrDefault(b => b.Id == id);
                        
            if (s is not null)
            {
                context.Remove(s);
                _dbContext.SaveChanges();
            }
        }

    }
}

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
            // _dbContext.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
            var context = _dbContext.Shipments;
            return await context.ToListAsync();

        }
        public async Task<Shipment> GetShipment(int id)
        {

            var context = _dbContext.Shipments;
            var shipment = context.Where(b => b.Id== id).FirstOrDefault();
            return shipment;
        }

        public async Task InsertShipment(Shipment shipment)
        {
            //_dbContext.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
            var context = _dbContext.Shipments;
            var sh = context.Where(b => b.Id == shipment.Id).FirstOrDefault();
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
            var sh = context.Where(b => b.Id == shipment.Id).FirstOrDefault();
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
            var s = (from b in context
                     where b.Id == shipment.Id
                     select b).FirstOrDefault();


            if (s is not null)
            {
                context.Remove(shipment);
                _dbContext.SaveChanges();
            }
            
        }



        public async Task DeleteShipment(int id)
        {
            var context = _dbContext.Shipments;
            var s = (from b in context
                        where b.Id == id
                        select b).FirstOrDefault();

            
            if (s is not null)
            {
                context.Remove(s);
                _dbContext.SaveChanges();
            }
        }

    }
}

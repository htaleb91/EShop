using EShop.Data;
using EShop.Entities.Domain;
using Microsoft.EntityFrameworkCore;

namespace EShop.Services
{
    public class OrderNoteService : IOrderNoteService
    {

        private ApplicationDbContext _dbContext;

        public OrderNoteService(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IList<OrderNote>> GetAllOrderNotes()
        {
            // _dbContext.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
            var context = _dbContext.OrderNotes;
            return await context.ToListAsync();

        }
        public async Task<OrderNote> GetOrderNote(int id)
        {

            var context = _dbContext.OrderNotes;
            var orderNote = context.Where(b => b.Id== id).FirstOrDefault();
            return orderNote;
        }

        public async Task InsertOrderNote(OrderNote orderNote)
        {
            //_dbContext.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
            var context = _dbContext.OrderNotes;
            var note = context.Where(b => b.Id == orderNote.Id).FirstOrDefault();
            if (note is not null)
            {
                orderNote.CreatedOnUtc = DateTime.UtcNow;
                await context.AddAsync(orderNote);
                _dbContext.SaveChanges();
            }
            
        }

        public async Task UpdateOrderNote(OrderNote orderNote)
        {
            var context = _dbContext.OrderNotes;
            var note = context.Where(b => b.Id == orderNote.Id).FirstOrDefault();
            if (note is not null)
            {
                orderNote.UpdatedOnUtc = DateTime.UtcNow;
                context.Update(orderNote);
                _dbContext.SaveChanges();
            }
            
        }

        public async Task DeleteOrderNote(OrderNote orderNote)
        {
            var context = _dbContext.OrderNotes;
            var query = (from b in context
                        where b.Id == orderNote.Id
                        select b).FirstOrDefault();

            
            if (query is not null)
            {
                context.Remove(orderNote);
                _dbContext.SaveChanges();
            }
        }



        public async Task DeleteOrderNote(int id)
        {
            var context = _dbContext.OrderNotes;
            var query = (from b in context
                        where b.Id == id
                        select b).FirstOrDefault();

            
            if (query is not null)
            {
                context.Remove(query);
                _dbContext.SaveChanges();
            }
        }

    }
}

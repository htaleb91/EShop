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
            var context = _dbContext.OrderNotes;
            return await context.ToListAsync();

        }
        public async Task<OrderNote> GetOrderNote(int id)
        {

            var context = _dbContext.OrderNotes;
            var orderNote = context.FirstOrDefault(b => b.Id == id);
            return orderNote;
        }

        public async Task InsertOrderNote(OrderNote orderNote)
        {
            var context = _dbContext.OrderNotes;
            var note = context.FirstOrDefault(b => b.Id == orderNote.Id);
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
            var note = context.FirstOrDefault(b => b.Id == orderNote.Id);
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
            var query = context.FirstOrDefault(b => b.Id == orderNote.Id);
            
            if (query is not null)
            {
                context.Remove(orderNote);
                _dbContext.SaveChanges();
            }
        }



        public async Task DeleteOrderNote(int id)
        {
            var context = _dbContext.OrderNotes;
            var query = context.FirstOrDefault(b => b.Id == id);
            
            if (query is not null)
            {
                context.Remove(query);
                _dbContext.SaveChanges();
            }
        }

    }
}

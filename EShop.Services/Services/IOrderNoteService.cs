using EShop.Entities.Domain;

namespace EShop.Services
{
    public interface IOrderNoteService
    {
        Task DeleteOrderNote(int id);
        Task DeleteOrderNote(OrderNote OrderNote);
        Task<IList<OrderNote>> GetAllOrderNotes();
        Task<OrderNote> GetOrderNote(int id);
        Task InsertOrderNote(OrderNote OrderNote);
        Task UpdateOrderNote(OrderNote OrderNote);
    }
}
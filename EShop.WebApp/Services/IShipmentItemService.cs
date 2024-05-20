using EShop.Entities.Domain;

namespace EShop.Services
{
    public interface IShipmentItemService
    {
        Task DeleteShipmentItem(int id);
        Task DeleteShipmentItem(ShipmentItem ShipmentItem);
        Task<IList<ShipmentItem>> GetAllShipmentItems();
        Task<ShipmentItem> GetShipmentItem(int id);
        Task InsertShipmentItem(ShipmentItem ShipmentItem);
        Task UpdateShipmentItem(ShipmentItem ShipmentItem);
    }
}
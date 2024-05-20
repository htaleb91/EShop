using EShop.Entities.Domain;

namespace EShop.Services
{
    public interface IShipmentService
    {
        Task DeleteShipment(int id);
        Task DeleteShipment(Shipment Shipment);
        Task<IList<Shipment>> GetAllShipments();
        Task<Shipment> GetShipment(int id);
        Task InsertShipment(Shipment Shipment);
        Task UpdateShipment(Shipment Shipment);
    }
}
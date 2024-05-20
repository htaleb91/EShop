
namespace EShop.Framework.Models
{
    /// <summary>
    /// Represents base EShop entity model
    /// </summary>
    public partial record BaseEShopEntityModel : BaseEShopModel
    {
        /// <summary>
        /// Gets or sets model identifier
        /// </summary>
        public virtual int Id { get; set; }
    }
}
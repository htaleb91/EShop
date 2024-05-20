
namespace EShop.Framework.Models
{
    /// <summary>
    /// Represents base EShop entity model
    /// </summary>
    public partial record BaseEShopIdentityEntityModel : BaseEShopModel
    {
        /// <summary>
        /// Gets or sets model identifier
        /// </summary>
        public virtual string Id { get; set; }
    }
}
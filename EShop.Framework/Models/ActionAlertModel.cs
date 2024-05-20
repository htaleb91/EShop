using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EShop.Framework.Models
{
    public record ActionAlertModel : BaseEShopIdentityEntityModel
    {
        /// <summary>
        /// Window ID
        /// </summary>
        public string WindowId { get; set; }
        /// <summary>
        /// Alert ID
        /// </summary>
        public string AlertId { get; set; }
        /// <summary>
        /// Alert message
        /// </summary>
        public string AlertMessage { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EShop.Framework.Models
{
    public record DeleteConfirmationModel : BaseEShopModel
    {
        /// <summary>
        /// Identifier
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// Controller name
        /// </summary>
        public string ControllerName { get; set; }

        /// <summary>
        /// Action name
        /// </summary>
        public string ActionName { get; set; }

        /// <summary>
        /// Window ID
        /// </summary>
        public string WindowId { get; set; }
    }
}

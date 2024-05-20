using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace EShop.Framework.TagHelpers.Admin
{
    /// <summary>
    /// "EShop-cards" tag helper
    /// </summary>
    [HtmlTargetElement("eshop-cards", Attributes = ID_ATTRIBUTE_NAME)]
    public class EShopCardsTagHelper : TagHelper
    {
        #region Constants

        private const string ID_ATTRIBUTE_NAME = "id";

        #endregion

        #region Properties

        /// <summary>
        /// ViewContext
        /// </summary>
        [HtmlAttributeNotBound]
        [ViewContext]
        public ViewContext ViewContext { get; set; }

        #endregion
    }
}
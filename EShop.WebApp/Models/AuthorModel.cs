using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;
using System.Globalization;

namespace EShop.Models
{
    public class AuthorModel
    {
        public AuthorModel()
        {
            CountriesList = CountryList();
            
        }

        public int Id { get; set; }

        [Required(ErrorMessage = "Name is required")]
        [StringLength(100, ErrorMessage = "Name at most could be 100 character")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Country is required")]
        [StringLength(100, ErrorMessage = "Country at most could be 100 character")]
        public string Country { get; set; }
        public IList<SelectListItem> CountriesList { get; set; }


        [Required(ErrorMessage = "Birthday is required")]
        public DateTime Birthday { get; set; }

        public static IList<SelectListItem> CountryList()
        {

            //Create a Dictionary
            List<SelectListItem> countries = new List<SelectListItem>();
            countries.Add(new SelectListItem { Text = "All", Value = null });
            //Get specific CultureInfo
            CultureInfo[] getCultureInfo = CultureInfo.GetCultures(CultureTypes.SpecificCultures);
            
            foreach (CultureInfo getCulture in getCultureInfo)
            {
                RegionInfo getRegionInfo = new RegionInfo(getCulture.LCID);

                countries.Add(new SelectListItem { Text = getRegionInfo.EnglishName + "( "+ getRegionInfo.Name + " )", Value = getRegionInfo.EnglishName });

            }
            countries = countries.GroupBy(x => x.Text).Select(x => x.First()).ToList();
            countries = countries.OrderBy(x => x.Value).Select(x => x).ToList();
            //return country dictionary
            return countries;

        }
    }
}

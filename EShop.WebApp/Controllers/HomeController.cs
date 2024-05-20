
using EShop.Entities.Domain;
using EShop.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Security.Claims;

namespace EShop.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly UserManager<User> _userManager;
        private readonly IPictureService _pictureService;

        public HomeController(ILogger<HomeController> logger, UserManager<User> userManager, IPictureService pictureService)
        {
            _logger = logger;
            _userManager = userManager;
            _pictureService = pictureService;
        }

        public async Task<IActionResult> Index()
        {
            var currentUser = await _userManager.GetUserAsync(User);
            if (currentUser is not null)
            {
                var picture = await _pictureService.GetPicture( currentUser.PictureId);
                if(picture.Bytes is not null && picture.Id>0)
                {

                string base64String = Convert.ToBase64String(picture.Bytes, 0, (int)picture.Size);
                ViewBag.UserImageSrc = "data:Image/png;base64," + base64String;
                }
            }
            ViewBag.CurrentUser = currentUser;
            return View();
        }
        public IActionResult Contact()
        {
            return View();
        }
        public IActionResult About()
        {
            return View();
        }
        public IActionResult Shop()
        {
            return View();
        }
        public IActionResult ShopSingle()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }
        public void ChangeLanguage(string culture,string returnUrl)
        {
            
            if (culture != null)
            {

                Response.Cookies.Append(
                CookieRequestCultureProvider.DefaultCookieName,
               CookieRequestCultureProvider.MakeCookieValue(new RequestCulture(culture)),
               new CookieOptions { Expires = DateTimeOffset.UtcNow.AddYears(1) });
            }
            if (!string.IsNullOrEmpty(returnUrl))
            {
                Response.Redirect(Request.Headers["Referer"].ToString() ?? $"/{returnUrl}");
            }
            string _returnUrl = Request.Headers["Referer"].ToString() ?? "/";
            Response.Redirect(_returnUrl);
        }
        //[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        //public IActionResult Error()
        //{
        //    return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        //}
    }
}

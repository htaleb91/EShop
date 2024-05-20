using EShop.Entities.Domain;
using EShop.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc;
using System.Text.RegularExpressions;

namespace EShop.Areas.Admin.Controllers
{
    [Area("admin")]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        private readonly UserManager<User> _userManager;
        private readonly IPictureService _pictureService;

        public HomeController(UserManager<User> userManager, IPictureService pictureService, ILogger<HomeController> logger)
        {
            _userManager = userManager;
            _pictureService = pictureService;
            _logger = logger;
        }
        // GET: HomeController
        public async Task<ActionResult> Index()
        {
            var currentUser = await _userManager.GetUserAsync(User);
            if (currentUser is null)
            {
                return RedirectToAction("Index","Home", new { area = "" });
            }
          
            return View();
        }

        // GET: HomeController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: HomeController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: HomeController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: HomeController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: HomeController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: HomeController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: HomeController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        public void ChangeLanguage(string culture, string returnUrl)
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
    }
}

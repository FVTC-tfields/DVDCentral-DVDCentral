using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TSF.DVDCentral.BL;
using TSF.DVDCentral.BL.Models;
using TSF.DVDCentral.UI.Extensions;

namespace TSF.DVDCentral.UI.Controllers
{
    public class UserController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Seed()
        {
            UserManager.Seed();
            return View();
        }

        private void SetUser(User user)
        {

            HttpContext.Session.SetObject("user", user);

            if (user != null)
            {
                HttpContext.Session.SetObject("fullname", "Welcome " + user.FullName);
            }
            else
            {
                HttpContext.Session.SetObject("fullname", string.Empty);
            }
        }

        public IActionResult Logout()
        {
            ViewBag.Title = "Logout";
            SetUser(null);
            return View();
        }

        public IActionResult Login(string returnUrl)
        {
            TempData["returnUrl"] = returnUrl;
            ViewBag.Title = "Login";
            return View();
        }

        [HttpPost]
        public IActionResult Login(User user)
        {
            try
            {
                bool result = UserManager.Login(user);
                SetUser(user);

                if (TempData["returnUrl"] != null)
                    return Redirect(TempData["returnUrl"]?.ToString());

                return RedirectToAction(nameof(Index), "Declaration");
            }
            catch (Exception ex)
            {
                ViewBag.Title = "Login";
                ViewBag.Error = ex.Message;
                return View(user);
            }
        }
    }
}

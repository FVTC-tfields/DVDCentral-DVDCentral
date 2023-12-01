using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Mvc;
using TSF.DVDCentral.BL;
using TSF.DVDCentral.BL.Models;
using TSF.DVDCentral.UI.Models;

namespace TSF.DVDCentral.UI.Controllers
{
    public class GenreController : Controller
    {
        public IActionResult Index()
        {
            return View(GenreManager.Load());
        }

        public IActionResult Details(int id)
        {
            return View(GenreManager.LoadById(id));
        }

        public IActionResult Create()
        {
            ViewBag.Title = "Create a Genre";
            if (Authenticate.IsAuthenticated(HttpContext))
                return View();
            else
                return RedirectToAction("Login", "User", new { returnUrl = UriHelper.GetDisplayUrl(HttpContext.Request) });
        }

        [HttpPost]
        public IActionResult Create(Genre genre)
        {
            try
            {
                int result = GenreManager.Insert(genre);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception)
            {

                throw;
            }
        }

        public IActionResult Edit(int id)
        {
            ViewBag.Title = "Edit a Genre";
            if (Authenticate.IsAuthenticated(HttpContext))
                return View(RatingManager.LoadById(id));
            else
                return RedirectToAction("Login", "User", new { returnUrl = UriHelper.GetDisplayUrl(HttpContext.Request) });
        }

        [HttpPost]
        public IActionResult Edit(int id, Genre genre, bool rollback = false)
        {
            try
            {
                int result = GenreManager.Update(genre, rollback);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.Message;
                return View(genre);
            }
        }

        public IActionResult Delete(int id)
        {
            return View(GenreManager.LoadById(id));
        }

        [HttpPost]
        public IActionResult Delete(int id, Genre genre, bool rollback = false)
        {
            try
            {
                int result = GenreManager.Delete(id, rollback);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.Message;
                return View(genre);
            }
        }
    }
}

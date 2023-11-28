using Microsoft.AspNetCore.Mvc;
using TSF.DVDCentral.BL;

namespace TSF.DVDCentral.UI.Controllers
{
    public class MovieController : Controller
    {
        public IActionResult Index()
        {
            ViewBag.Title = "List of Movies";
            return View(MovieManager.Load());
        }

        public IActionResult Browse(int id)
        {
            if (id == -1)
            {
                return View(nameof(Index), MovieManager.Load(null));
            }

            return View(nameof(Index), MovieManager.Load(id));
        }
    }
}

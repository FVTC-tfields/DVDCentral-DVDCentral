using Microsoft.AspNetCore.Mvc;
using TSF.DVDCentral.BL;

namespace TSF.DVDCentral.UI.Controllers
{
    public class MovieController : Controller
    {
        public IActionResult Index()
        {
            return View(MovieManager.Load());
        }
    }
}

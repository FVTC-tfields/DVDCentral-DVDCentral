using Microsoft.AspNetCore.Mvc;

namespace TSF.WebApp2.Controllers
{
    public class BingoController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}

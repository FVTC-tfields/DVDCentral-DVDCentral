using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TSF.DVDCentral.BL;

namespace TSF.DVDCentral.UI.Controllers
{
    public class OrderItemController : Controller
    {
        // GET: OrderItemController
        public ActionResult Index()
        {
            ViewBag.Title = "List of Order Items";
            return View(OrderItemManager.Load());
        }
    }
}

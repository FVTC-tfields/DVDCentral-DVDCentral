using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Mvc;
using TSF.DVDCentral.BL;
using TSF.DVDCentral.BL.Models;

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

        public ActionResult Delete(int orderId, int orderItemId)
        {
            var result = OrderItemManager.Delete(orderItemId);

            return RedirectToAction("Edit", "Order", new { id = orderId });

        }
    }
}

using Microsoft.AspNetCore.Mvc;
using TSF.DVDCentral.BL.Models;
using TSF.DVDCentral.UI.Extensions;

namespace TSF.DVDCentral.UI.ViewComponents
{
    public class ShoppingCartComponent : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            if (HttpContext.Session.GetObject<ShoppingCart>("cart") != null)
            {
                return View(HttpContext.Session.GetObject<ShoppingCart>("cart"));
            }
            else
            {
                return View(new ShoppingCart());
            }
        }
    }
}

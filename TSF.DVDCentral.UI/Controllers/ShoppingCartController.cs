using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using TSF.DVDCentral.BL;
using TSF.DVDCentral.BL.Models;
using TSF.DVDCentral.UI.Extensions;
using TSF.DVDCentral.UI.Models;
using TSF.DVDCentral.UI.ViewModels;

namespace TSF.DVDCentral.UI.Controllers
{
    public class ShoppingCartController : Controller
    {
        ShoppingCart cart;
        
        // GET: ShoppingCartController
        public ActionResult Index()
        {
            ViewBag.Title = "Shopping Cart";
            cart = GetShoppingCart();

            return View(cart);
        }

        private ShoppingCart GetShoppingCart()
        {
            if (HttpContext.Session.GetObject<ShoppingCart>("cart") != null)
            {
                return HttpContext.Session.GetObject<ShoppingCart>("cart");
            }
            else
            {
                return new ShoppingCart();
            }
        }
        
        public IActionResult Remove(int id) 
        {
            cart = GetShoppingCart();
            Movie movie = cart.Items.FirstOrDefault(i => i.Id == id);
            ShoppingCartManager.Remove(cart, movie);

            HttpContext.Session.SetObject("cart", cart);
            return RedirectToAction(nameof(Index));
        }
        
        public IActionResult Add(int id)
        {
            cart = GetShoppingCart();
            Movie movie = MovieManager.LoadById(id);
            ShoppingCartManager.Add(cart, movie);
            HttpContext.Session.SetObject("cart", cart);

            return RedirectToAction(nameof(Index), "Movie");
        }

        public IActionResult Checkout()
        {
            if (Authenticate.IsAuthenticated(HttpContext))
            {
                return RedirectToAction("AssignToCustomer", "ShoppingCart", new { returnUrl = UriHelper.GetDisplayUrl(HttpContext.Request) });
            }
            else
            {
                return RedirectToAction("Login", "User", new { returnUrl = UriHelper.GetDisplayUrl(HttpContext.Request) });
            }

        }

        public IActionResult AssignToCustomer()
        {
            User user = HttpContext.Session.GetObject<User>("user");

            CustomerVM customerVM = new CustomerVM();
            customerVM.Cart = GetShoppingCart();
            customerVM.UserId = user.Id;
            customerVM.Customers = CustomerManager.Load();

            Customer? customer = CustomerManager.LoadByUserId(user.Id);
            if (customer != null)
            {
                customerVM.CustomerId = customer.Id;
            }

            ViewData["ReturnUrl"] = UriHelper.GetDisplayUrl(HttpContext.Request);

            return View(customerVM);
        }

        [HttpPost]
        public IActionResult AssignToCustomer(CustomerVM customerVM)
        {
            cart = GetShoppingCart();
            ShoppingCartManager.Checkout(cart, customerVM.UserId, customerVM.CustomerId);
            HttpContext.Session.SetObject("cart", null);

            return View("CheckOut", cart);
        }
    }
}

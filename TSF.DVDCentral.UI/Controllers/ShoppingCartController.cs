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
        //public ActionResult AssignToCustomer()
        //{
        //    // Get the user from Session

        //    // Instantiate a new instance of the CustomerViewModel view model

        //    // Instantiate a new instance of Customer object.

        //    // Get and put the cart into the ViewModel

        //    // Load ViewModel.Customers list.

        //    // Set the UserId in the Viewmodel

        //    // if the UserId has any customers, set the ViewModel.CustomerId to the first one.  Could have more than one.

        //    // Put the ViewModel in session.

        //    // Set the ViewData["ReturnUrl"] to the UriHelper.GetDisplayUrl(HttpContext.Request);

        //    // return the view with viewmodel as the model

        //}

        //[HttpPost]
        //public ActionResult AssignToCustomer(CustomerViewModel customerViewModel)
        //{
        //    try
        //    {
        //        // Get and assign the ViewModel.Cart

        //        // Add the Order like you did in the Checkout Method for Checkpoint #7

        //        // Clear the Shopping cart

        //        // Show the thank you for your order screen

        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}


        //public ActionResult AssignToCustomer()
        //{
        //    User user = HttpContext.Session.GetObject<User>("user");
        //    Customer customer = new Customer();
        //    CustomerViewModel cartCustomers = new CustomerViewModel();
        //    cartCustomers.Cart = GetShoppingCart();
        //    cartCustomers.Customers = new List<Customer>();
        //    cartCustomers.Customers = CustomerManager.Load();
        //    cartCustomers.UserId = user.Id;

        //    if (cartCustomers.Customers.Where(c => c.UserId == user.Id).FirstOrDefault() != null)
        //        cartCustomers.CustomerId = cartCustomers.Customers.Where(c => c.UserId == user.Id).FirstOrDefault().Id;

        //    HttpContext.Session.SetObject("cartCustomers", cartCustomers);

        //    ViewData["ReturnUrl"] = UriHelper.GetDisplayUrl(HttpContext.Request);
        //    return View(cartCustomers);
        //}


        // GET: ShoppingCart
        //public ActionResult Index()
        //{
        //    cart = GetShoppingCart();
        //    return View(cart);
        //}

        //public ActionResult RemoveFromCart(int id)
        //{
        //    GetShoppingCart();
        //    Movie movie = cart.Items.FirstOrDefault(i => i.Id == id);
        //    cart.Remove(movie);
        //    HttpContext.Session.SetObject("cart", cart);
        //    return RedirectToAction("Index");
        //}

        //public ActionResult AddToCart(int id)
        //{
        //    cart = GetShoppingCart();
        //    Movie movie = new Movie();
        //    movie = MovieManager.LoadById(id);
        //    ShoppingCartManager.Add(cart, movie);
        //    HttpContext.Session.SetObject("cart", cart);
        //    return RedirectToAction("Index", "Movie");
        //}

        //private ShoppingCart GetShoppingCart()
        //{
        //    if (HttpContext.Session.GetObject<ShoppingCart>("cart") != null)
        //    {
        //        return (ShoppingCart)HttpContext.Session.GetObject<ShoppingCart>("cart");
        //    }
        //    else
        //    {
        //        return new ShoppingCart();
        //    }
        //}

        //// GET: Order/Create
        //public ActionResult Checkout()
        //{
        //    User user = new User();
        //    if (HttpContext.Session.GetObject<User>("user") == null)
        //    {
        //        return RedirectToAction("Login", "User", new { returnUrl = UriHelper.GetDisplayUrl(HttpContext.Request) });
        //    }
        //    else
        //    {

        //        return RedirectToAction("AssignToCustomer");
        //    }

        //}

        //// POST: Order/Create
        //[HttpPost]
        //public ActionResult AssignToCustomer(CustomerViewModel cartCustomers)
        //{
        //    try
        //    {
        //        // TODO: Add insert logic here
        //        cartCustomers.Cart = GetShoppingCart();

        //        Order order = new Order();
        //        order.CustomerId = cartCustomers.CustomerId;
        //        order.UserId = cartCustomers.UserId;
        //        cartCustomers.Cart.Items.ForEach(a => order.OrderItems.Add(new OrderItem
        //        {
        //            OrderId = order.Id,
        //            MovieId = a.Id,
        //            Cost = a.Cost,
        //            Quantity = a.Quantity
        //        }));
        //        OrderManager.Insert(order);
        //        HttpContext.Session.SetObject("cart", cart);

        //        return View("ThankYou");

        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}
    }
}

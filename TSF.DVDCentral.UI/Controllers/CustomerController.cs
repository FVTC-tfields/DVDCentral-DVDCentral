using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Mvc;
using TSF.DVDCentral.BL;
using TSF.DVDCentral.BL.Models;
using TSF.DVDCentral.UI.Models;

namespace TSF.DVDCentral.UI.Controllers
{
    public class CustomerController : Controller
    {
        public IActionResult Index(string returnurl)
        {
            if (returnurl != null)
            {
                return Redirect(returnurl);
            }

            return View(CustomerManager.Load());
        }

        public IActionResult Details(int id)
        {
            return View(CustomerManager.LoadById(id));
        }

        public IActionResult Create(string returnurl)
        {
            ViewData["returnurl"] = returnurl;

            ViewBag.Title = "Create a Customer";
            if (Authenticate.IsAuthenticated(HttpContext))
                return View();
            else
                return RedirectToAction("Login", "User", new { returnUrl = UriHelper.GetDisplayUrl(HttpContext.Request) });
        }

        [HttpPost]
        public IActionResult Create(Customer customer, string returnurl)
        {
            try
            {
                int result = CustomerManager.Insert(customer);

                if (returnurl != null)
                {
                    return Redirect(returnurl);
                }

                return RedirectToAction(nameof(Index));
            }
            catch (Exception)
            {

                throw;
            }
        }

        public IActionResult Edit(int id)
        {
            ViewBag.Title = "Edit a Customer";
            if (Authenticate.IsAuthenticated(HttpContext))
                return View(RatingManager.LoadById(id));
            else
                return RedirectToAction("Login", "User", new { returnUrl = UriHelper.GetDisplayUrl(HttpContext.Request) });
        }

        [HttpPost]
        public IActionResult Edit(int id, Customer customer, bool rollback = false)
        {
            try
            {
                int result = CustomerManager.Update(customer, rollback);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.Message;
                return View(customer);
            }
        }

        public IActionResult Delete(int id)
        {
            return View(CustomerManager.LoadById(id));
        }

        [HttpPost]
        public IActionResult Delete(int id, Customer customer, bool rollback = false)
        {
            try
            {
                int result = CustomerManager.Delete(id, rollback);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.Message;
                return View(customer);
            }
        }
    }
}

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace TSF.DVDCentral.UI.Controllers
{
    public class AssigntoCustomer : Controller
    {
        // GET: AssigntoCustomer
        public ActionResult Index()
        {
            return View();
        }

        // GET: AssigntoCustomer/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: AssigntoCustomer/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: AssigntoCustomer/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: AssigntoCustomer/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: AssigntoCustomer/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: AssigntoCustomer/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: AssigntoCustomer/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}

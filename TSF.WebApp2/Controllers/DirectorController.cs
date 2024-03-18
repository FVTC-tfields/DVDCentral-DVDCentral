using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TSF.DVDCentral.BL;
using TSF.DVDCentral.BL.Models;
using TSF.DVDCentral.PL2.Data;
using TSF.DVDCentral.UI.Models;

namespace TSF.WebApp2.Controllers
{
    public class DirectorController : Controller
    {
        private readonly DbContextOptions<DVDCentralEntities> options;

        public DirectorController(ILogger<DirectorController> logger,
                                DbContextOptions<DVDCentralEntities> options)
        {
            this.options = options;
        }

        [AllowAnonymous]
        public IActionResult Index()
        {
            return View(new DirectorManager(options).Load());
        }

        [AllowAnonymous]
        public IActionResult Details(Guid id)
        {
            return View(new DirectorManager(options).LoadById(id));
        }

        [Authorize]
        public IActionResult Create()
        {
            ViewBag.Title = "Create a Director";
            if (Authenticate.IsAuthenticated(HttpContext))
                return View();
            else
                return RedirectToAction("Login", "User", new { returnUrl = UriHelper.GetDisplayUrl(HttpContext.Request) });
        }

        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Director director)
        {
            try
            {
                int result = new DirectorManager(options).Insert(director);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception)
            {

                throw;
            }
        }

        public IActionResult Edit(Guid id)
        {
            ViewBag.Title = "Edit a Director";
            if (Authenticate.IsAuthenticated(HttpContext))
                return View(new DirectorManager(options).LoadById(id));
            else
                return RedirectToAction("Login", "User", new { returnUrl = UriHelper.GetDisplayUrl(HttpContext.Request) });
        }

        [HttpPost]
        public IActionResult Edit(Guid id, Director director, bool rollback = false)
        {
            try
            {
                int result = new DirectorManager(options).Update(director, rollback);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.Message;
                return View(director);
            }
        }

        public IActionResult Delete(Guid id)
        {
            return View(new DirectorManager(options).LoadById(id));
        }

        [HttpPost]
        public IActionResult Delete(Guid id, Director director, bool rollback = false)
        {
            try
            {
                int result = new DirectorManager(options).Delete(id, rollback);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.Message;
                return View(director);
            }
        }
    }
}

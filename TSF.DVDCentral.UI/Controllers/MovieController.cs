using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.Web.CodeGeneration.Design;
using TSF.DVDCentral.BL;
using TSF.DVDCentral.BL.Models;
using TSF.DVDCentral.UI.Models;
using TSF.DVDCentral.UI.ViewModels;

namespace TSF.DVDCentral.UI.Controllers
{
    public class MovieController : Controller
    {
        private readonly IWebHostEnvironment _host;
        public IActionResult Index()
        {
            ViewBag.Title = "List of Movies";
            return View(MovieManager.Load());
        }

        public IActionResult Browse(int id)
        {
            if (id == -1)
            {
                return View(nameof(Index), MovieManager.Load(null));
            }

            return View(nameof(Index), MovieManager.Load(id));
        }
        public IActionResult Delete(int id)
        {
            return View(MovieManager.LoadById(id));
        }

        [HttpPost]
        public IActionResult Delete(int id, Movie movie, bool rollback = false)
        {
            try
            {
                int result = MovieManager.Delete(id, rollback);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.Message;
                return View(movie);
            }
        }
        public IActionResult Edit(int id)
        {
            if (Authenticate.IsAuthenticated(HttpContext))
            {
                MovieVM movieVM = new MovieVM();

                movieVM.Movie = MovieManager.LoadById(id);
                movieVM.Directors = DirectorManager.Load();
                movieVM.Genres = GenreManager.Load();
                movieVM.Ratings = RatingManager.Load();
                movieVM.Formats = FormatManager.Load();

                ViewBag.Title = "Edit " + movieVM.Movie.Description;

                return View(movieVM);
            }
            else
                return RedirectToAction("Login", "User", new { returnUrl = UriHelper.GetDisplayUrl(HttpContext.Request) });
        }

        [HttpPost]
        public IActionResult Edit(int id, MovieVM movieVM, bool rollback = false)
        {
            try
            {
                // Process the image
                if (movieVM.File != null)
                {
                    movieVM.Movie.ImagePath = movieVM.File.FileName;
                    string path = _host.WebRootPath + "\\images\\";
                    using (var stream = System.IO.File.Create(path + movieVM.File.FileName))
                    {
                        movieVM.File.CopyTo(stream);
                        ViewBag.Message = "File Uploaded Successfully...";
                    }
                }

                int result = MovieManager.Update(movieVM.Movie, rollback);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.Message;
                return View(movieVM);
            }
        }
        public IActionResult Create()
        {
            ViewBag.Title = "Create a Movie";

            MovieVM movieVM = new MovieVM();

            movieVM.Movie = new BL.Models.Movie();
            movieVM.Directors = DirectorManager.Load();
            movieVM.Genres = GenreManager.Load();
            movieVM.Ratings = RatingManager.Load();
            movieVM.Formats = FormatManager.Load();

            if (Authenticate.IsAuthenticated(HttpContext))
                return View(movieVM);
            else
                return RedirectToAction("Login", "User", new { returnUrl = UriHelper.GetDisplayUrl(HttpContext.Request) });
        }

        [HttpPost]
        public IActionResult Create(MovieVM movieVM)
        {
            try
            {
                int result = MovieManager.Insert(movieVM.Movie);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}

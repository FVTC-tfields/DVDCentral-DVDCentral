using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TSF.DVDCentral.BL;

namespace TSF.DVDCentral.UI.ViewComponents
{
    public class Sidebar : ViewComponent
    {
        //public IViewComponentResult Invoke()
        //{
        //    var data = GenreManager.Load().OrderBy(p => p.Description).ToList();
        //    var allGenre = new BL.Models.Genre()
        //    {
        //        Id = -1,
        //        Description = "All"
        //    };
        //    data.Add(allGenre);

        //    return View(data);
        //}

        public IViewComponentResult Invoke()
        {
            return View(GenreManager.Load().OrderBy(p => p.Description));
        }
    }
}

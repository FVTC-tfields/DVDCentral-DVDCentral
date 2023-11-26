using TSF.DVDCentral.BL;
using TSF.DVDCentral.BL.Models;

namespace TSF.DVDCentral.UI.ViewModels
{
    public class MovieVM
    {
        public BL.Models.Movie Movie { get; set; }
        public List<Genre> Genres { get; set; }
        public List<Director> Directors { get; set; }
        public List<Rating> Ratings { get; set; }
        public List<Format> Formats { get; set; }
        public IFormFile File { get; set; }
        public IEnumerable<int> GenreIds { get; set; }

    }
}

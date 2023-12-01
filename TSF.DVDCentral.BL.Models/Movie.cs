using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TSF.DVDCentral.BL.Models
{
    public class Movie
    {
        public int Id { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }
        [DisplayName("Format Id")]
        public int FormatId { get; set; }
        [DisplayName("Director Id")]
        public int DirectorId { get; set; }
        [DisplayName("Rating Id")]
        public int RatingId { get; set; }
        public float Cost { get; set; }
        [DisplayName("In Stock Quantity")]
        public int InStkQty { get; set; }
        [DisplayName("Image")]
        public string? ImagePath { get; set; }
        public List<Genre> Genres { get; set; } = new List<Genre>();

    }
}

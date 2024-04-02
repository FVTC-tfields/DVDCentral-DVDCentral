using System;
using System.Collections.Generic;

#nullable disable

namespace TSF.DVDCentral.PL2.Entities
{

    public class tblMovieGenre : IEntity
    {
        public Guid Id { get; set; }

        public Guid MovieId { get; set; }

        public Guid GenreId { get; set; }

        public virtual tblGenre Genre { get; set; }
        public virtual tblMovie Movie { get; set; }
        public string SortField { get { return Movie.Title; } }


    }

}
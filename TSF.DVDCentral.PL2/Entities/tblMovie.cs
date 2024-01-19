using System;
using System.Collections.Generic;

namespace TSF.DVDCentral.PL2.Entities;

public class tblMovie
{
    public Guid Id { get; set; }

    public string Title { get; set; } = null!;

    public string Description { get; set; } = null!;

    public Guid FormatId { get; set; }

    public Guid DirectorId { get; set; }

    public Guid RatingId { get; set; }

    public double Cost { get; set; }

    public int Quantity { get; set; }

    public string ImagePath { get; set; } = null!;
    public virtual ICollection<tblMovieGenre> tblMovieGenres { get; set; }
    public virtual tblDirector Director { get; set; }
    public virtual tblRating Rating { get; set; }
    public virtual tblFormat Format { get; set; }

}

using System;
using System.Collections.Generic;

namespace TSF.DVDCentral.PL2.Entities;

public class tblFormat
{
    public Guid Id { get; set; }

    public string Description { get; set; }
    public virtual ICollection<tblMovie> tblMovies { get; set; }
}

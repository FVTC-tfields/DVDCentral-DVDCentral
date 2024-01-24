using System;
using System.Collections.Generic;

namespace TSF.DVDCentral.PL2.Entities;

public class tblDirector
{
    public Guid Id { get; set; }

    public string FirstName { get; set; }

    public string LastName { get; set; }
    public virtual ICollection<tblMovie> tblMovies { get; set; }
}

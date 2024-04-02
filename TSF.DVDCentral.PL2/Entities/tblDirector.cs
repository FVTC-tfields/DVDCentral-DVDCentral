using System;
using System.Collections.Generic;

#nullable disable

namespace TSF.DVDCentral.PL2.Entities
{
    // Add a comment
    public class tblDirector : IEntity
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public virtual ICollection<tblMovie> tblMovies { get; set; }
        public string SortField { get { return LastName; } }
    }
}

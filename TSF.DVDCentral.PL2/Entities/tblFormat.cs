using System;
using System.Collections.Generic;

#nullable disable

namespace TSF.DVDCentral.PL2.Entities
{

    public class tblFormat : IEntity
    {
        public Guid Id { get; set; }

        public string Description { get; set; }
        public virtual ICollection<tblMovie> tblMovies { get; set; }
    }

}

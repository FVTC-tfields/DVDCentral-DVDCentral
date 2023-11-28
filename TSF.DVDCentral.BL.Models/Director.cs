﻿using Microsoft.EntityFrameworkCore.Metadata;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TSF.DVDCentral.BL.Models
{
    public class Director
    {
        public int Id { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }

        public string? FullName 
        {
            get
            {
                return this.FirstName + " " + this.LastName;
            }
        }

    }
}

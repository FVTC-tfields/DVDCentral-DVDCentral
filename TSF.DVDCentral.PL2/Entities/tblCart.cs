﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TSF.DVDCentral.PL2.Entities
{
    public class tblCart
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public virtual tblUser User { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using TSF.DVDCentral.BL.Models;

namespace TSF.DVDCentral.PL;

public partial class tblOrder
{
    public int Id { get; set; }

    public int CustomerId { get; set; }

    public DateTime OrderDate { get; set; }
    public DateTime ShipDate { get; set; }

    public int UserId { get; set; }
}

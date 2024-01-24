using System;
using System.Collections.Generic;

namespace TSF.DVDCentral.PL2.Entities;

public class tblCustomer
{
    public Guid Id { get; set; }

    public string FirstName { get; set; }

    public string LastName { get; set; }

    public Guid UserId { get; set; }

    public string Address { get; set; }

    public string City { get; set; }

    public string? State { get; set; }

    public string ZIP { get; set; }

    public string Phone { get; set; }
}

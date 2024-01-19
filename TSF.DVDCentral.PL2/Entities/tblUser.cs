using System;
using System.Collections.Generic;

namespace TSF.DVDCentral.PL2.Entities;

public class tblUser
{
    public Guid Id { get; set; }

    public string UserId { get; set; } = null!;
    public string UserName { get; set; } = null!;

    public string FirstName { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public string Password { get; set; } = null!;
}

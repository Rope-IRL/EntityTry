﻿using System;
using System.Collections.Generic;

namespace EntityTry;

public partial class SelectallLandlordInfoView
{
    public string Login { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string Name { get; set; } = null!;

    public string Surname { get; set; } = null!;

    public DateOnly BirthDate { get; set; }

    public string Telephone { get; set; } = null!;

    public string PassportId { get; set; } = null!;

    public decimal AvgMark { get; set; }
}

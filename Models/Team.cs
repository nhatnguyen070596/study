using System;
using System.Collections.Generic;

namespace study.Models;

public partial class Team
{
    public int TeamId { get; set; }

    public string? CountryName { get; set; }

    public int? ConfederationId { get; set; }
}

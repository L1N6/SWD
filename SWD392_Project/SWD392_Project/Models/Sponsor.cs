using System;
using System.Collections.Generic;

namespace SWD392_Project.Models;

public partial class Sponsor
{
    public long SponsorId { get; set; }

    public string Name { get; set; } = null!;

    public string? InforSponsor { get; set; }

    public string? UnitSponsor { get; set; }

    public long EventId { get; set; }

    public decimal? Amount { get; set; }

    public virtual Event Event { get; set; } = null!;
}

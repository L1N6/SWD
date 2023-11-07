using System;
using System.Collections.Generic;

namespace SWD392_Project.Models;

public partial class EventDetail
{
    public long DetailId { get; set; }

    public long EventId { get; set; }

    public string? Image { get; set; }

    public string? Agenda { get; set; }

    public virtual Event Event { get; set; } = null!;
}

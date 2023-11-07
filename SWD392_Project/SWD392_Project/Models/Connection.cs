using System;
using System.Collections.Generic;

namespace SWD392_Project.Models;

public partial class Connection
{
    public long AccountId { get; set; }

    public long EventId { get; set; }

    public bool JoinOrCare { get; set; }

    public virtual Account Account { get; set; } = null!;

    public virtual Event Event { get; set; } = null!;
}

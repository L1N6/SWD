using System;
using System.Collections.Generic;

namespace SWD392_Project.Models;

public partial class State
{
    public long StateId { get; set; }

    public string Name { get; set; } = null!;

    public virtual ICollection<Event> Events { get; set; } = new List<Event>();
}

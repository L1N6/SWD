using System;
using System.Collections.Generic;

namespace SWD392_Project.Models;

public partial class Category
{
    public long CategoryId { get; set; }

    public string Name { get; set; } = null!;

    public virtual ICollection<Event> Events { get; set; } = new List<Event>();
}

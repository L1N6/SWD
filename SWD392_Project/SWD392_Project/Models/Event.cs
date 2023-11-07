using System;
using System.Collections.Generic;

namespace SWD392_Project.Models;

public partial class Event
{
    public long EventId { get; set; }

    public string Name { get; set; } = null!;

    public string? Description { get; set; }

    public DateTime StartDate { get; set; }

    public DateTime EndDate { get; set; }

    public string? Location { get; set; }

    public long CategoryId { get; set; }

    public long AccountId { get; set; }

    public long? StateId { get; set; }

    public virtual Account Account { get; set; } = null!;

    public virtual Category Category { get; set; } = null!;

    public virtual ICollection<Comment> Comments { get; set; } = new List<Comment>();

    public virtual ICollection<EventDetail> EventDetails { get; set; } = new List<EventDetail>();

    public virtual ICollection<Sponsor> Sponsors { get; set; } = new List<Sponsor>();

    public virtual State? State { get; set; }
}

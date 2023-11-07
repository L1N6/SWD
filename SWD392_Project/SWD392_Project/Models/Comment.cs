using System;
using System.Collections.Generic;

namespace SWD392_Project.Models;

public partial class Comment
{
    public long CommentId { get; set; }

    public string Content { get; set; } = null!;

    public long AccountId { get; set; }

    public long EventId { get; set; }

    public DateTime CreatedAt { get; set; }

    public bool DeleteOrUpdate { get; set; }

    public virtual Account Account { get; set; } = null!;

    public virtual Event Event { get; set; } = null!;
}

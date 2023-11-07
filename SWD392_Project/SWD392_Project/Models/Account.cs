using System;
using System.Collections.Generic;

namespace SWD392_Project.Models;

public partial class Account
{
    public long AccountId { get; set; }

    public string UserName { get; set; } = null!;

    public string Password { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string? FullName { get; set; }

    public string? Phone { get; set; }

    public string? Address { get; set; }
    public string? Avatar { get; set; }

    public long RoleId { get; set; }

    public virtual ICollection<Comment> Comments { get; set; } = new List<Comment>();

    public virtual ICollection<Event> Events { get; set; } = new List<Event>();

    public virtual Role Role { get; set; } = null!;
}

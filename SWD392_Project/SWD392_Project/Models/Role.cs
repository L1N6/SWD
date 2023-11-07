using System;
using System.Collections.Generic;

namespace SWD392_Project.Models;

public partial class Role
{
    public long RoleId { get; set; }

    public string Name { get; set; } = null!;

    public virtual ICollection<Account> Accounts { get; set; } = new List<Account>();
}

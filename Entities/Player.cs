using System;
using System.Collections.Generic;

namespace Scaffold.Entities;

public partial class Player
{
    public int PlayerId { get; set; }

    public string? PlayerName { get; set; }

    public int? ShirtNumber { get; set; }

    public int? NumberOfGoals { get; set; }

    public string? Position { get; set; }

    public decimal? Salary { get; set; }

    public int? TeamId { get; set; }

    public virtual Team? Team { get; set; }
}

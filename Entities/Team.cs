using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Scaffold.Entities;

public partial class Team
{
    [Required]
    public int TeamId { get; set; }

    public string? TeamName { get; set; }

    public string? League { get; set; }

    public string? Country { get; set; }

    public decimal? Budget { get; set; }

    public int? Eyear { get; set; }

    public string? StadiumName { get; set; }

    public virtual ICollection<Player> Players { get; set; } = new List<Player>();
}

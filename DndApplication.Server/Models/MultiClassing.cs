using System;
using System.Collections.Generic;

namespace DndApplication.Server.Models;

public partial class MultiClassing
{
    public int ClassId { get; set; }

    public string AbilityScoreIndex { get; set; } = null!;

    public string AbilityScoreName { get; set; } = null!;

    public int MinimumScore { get; set; }

    public virtual Class Class { get; set; } = null!;
}

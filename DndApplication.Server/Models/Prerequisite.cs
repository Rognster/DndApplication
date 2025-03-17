using System;
using System.Collections.Generic;

namespace DndApplication.Server.Models;

public partial class Prerequisite
{
    public int Id { get; set; }

    public int FeatId { get; set; }

    public string AbilityScoreIndex { get; set; } = null!;

    public string AbilityScoreName { get; set; } = null!;

    public string AbilityScoreUrl { get; set; } = null!;

    public int MinimumScore { get; set; }

    public virtual Feat Feat { get; set; } = null!;
}

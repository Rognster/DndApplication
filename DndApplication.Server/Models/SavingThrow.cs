using System;
using System.Collections.Generic;

namespace DndApplication.Server.Models;

public partial class SavingThrow
{
    public int Id { get; set; }

    public int ClassId { get; set; }

    public string AbilityScoreIndex { get; set; } = null!;

    public string AbilityScoreName { get; set; } = null!;

    public string AbilityScoreUrl { get; set; } = null!;

    public virtual Class Class { get; set; } = null!;
}

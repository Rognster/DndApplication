using System;
using System.Collections.Generic;

namespace DndApplication.Server.Models;

public partial class RaceAbilityBonus
{
    public int Id { get; set; }

    public int RaceId { get; set; }

    public string AbilityScoreId { get; set; } = null!;

    public int Bonus { get; set; }

    public virtual AbilityScore AbilityScore { get; set; } = null!;

    public virtual Race Race { get; set; } = null!;
}

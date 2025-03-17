using System;
using System.Collections.Generic;

namespace DndApplication.Server.Models;

public partial class RaceAbilityBonusOption
{
    public int Id { get; set; }

    public int RaceId { get; set; }

    public int Bonus { get; set; }

    public string AbilityScoreIndex { get; set; } = null!;

    public virtual Race Race { get; set; } = null!;
}

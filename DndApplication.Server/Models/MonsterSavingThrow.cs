using System;
using System.Collections.Generic;

namespace DndApplication.Server.Models;

public partial class MonsterSavingThrow
{
    public int Id { get; set; }

    public int MonsterId { get; set; }

    public string AbilityScoreIndexId { get; set; } = null!;

    public int SavingThrowValue { get; set; }

    public virtual AbilityScore AbilityScoreIndex { get; set; } = null!;

    public virtual Monster Monster { get; set; } = null!;
}

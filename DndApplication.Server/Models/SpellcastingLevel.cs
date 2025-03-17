using System;
using System.Collections.Generic;

namespace DndApplication.Server.Models;

public partial class SpellcastingLevel
{
    public int Id { get; set; }

    public int LevelId { get; set; }

    public int? CantripsKnown { get; set; }

    public int? SpellsKnown { get; set; }

    public int? SpellSlotsLevel1 { get; set; }

    public int? SpellSlotsLevel2 { get; set; }

    public int? SpellSlotsLevel3 { get; set; }

    public int? SpellSlotsLevel4 { get; set; }

    public int? SpellSlotsLevel5 { get; set; }

    public int? SpellSlotsLevel6 { get; set; }

    public int? SpellSlotsLevel7 { get; set; }

    public int? SpellSlotsLevel8 { get; set; }

    public int? SpellSlotsLevel9 { get; set; }

    public virtual Level Level { get; set; } = null!;
}

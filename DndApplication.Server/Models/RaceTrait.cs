using System;
using System.Collections.Generic;

namespace DndApplication.Server.Models;

public partial class RaceTrait
{
    public int Id { get; set; }

    public int RaceId { get; set; }

    public int TraitId { get; set; }

    public virtual Race Race { get; set; } = null!;

    public virtual Trait Trait { get; set; } = null!;
}

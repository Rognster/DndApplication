using System;
using System.Collections.Generic;

namespace DndApplication.Server.Models;

public partial class Trait
{
    public int Id { get; set; }

    public string Index { get; set; } = null!;

    public string Name { get; set; } = null!;

    public string Url { get; set; } = null!;

    public string? Description { get; set; }

    public virtual ICollection<RaceTrait> RaceTraits { get; set; } = new List<RaceTrait>();

    public virtual ICollection<SubraceTrait> SubraceTraits { get; set; } = new List<SubraceTrait>();
}

using System;
using System.Collections.Generic;

namespace DndApplication.Server.Models;

public partial class MagicSchool
{
    public int Id { get; set; }

    public string Index { get; set; } = null!;

    public string Name { get; set; } = null!;

    public string Description { get; set; } = null!;

    public string Url { get; set; } = null!;

    public virtual ICollection<Spell> Spells { get; set; } = new List<Spell>();
}

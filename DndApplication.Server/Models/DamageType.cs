using System;
using System.Collections.Generic;

namespace DndApplication.Server.Models;

public partial class DamageType
{
    public int Id { get; set; }

    public string Index { get; set; } = null!;

    public string Name { get; set; } = null!;

    public string Url { get; set; } = null!;

    public virtual ICollection<DamageTypeDescription> DamageTypeDescriptions { get; set; } = new List<DamageTypeDescription>();

    public virtual ICollection<SpellDamage> SpellDamages { get; set; } = new List<SpellDamage>();
}

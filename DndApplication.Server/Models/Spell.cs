﻿using System;
using System.Collections.Generic;

namespace DndApplication.Server.Models;

public partial class Spell
{
    public int Id { get; set; }

    public string SpellIndex { get; set; } = null!;

    public string Name { get; set; } = null!;

    public string Description { get; set; } = null!;

    public string? HigherLevel { get; set; }

    public string Range { get; set; } = null!;

    public string Components { get; set; } = null!;

    public string? Material { get; set; }

    public bool Ritual { get; set; }

    public string Duration { get; set; } = null!;

    public bool Concentration { get; set; }

    public string CastingTime { get; set; } = null!;

    public int Level { get; set; }

    public int SchoolId { get; set; }

    public string Url { get; set; } = null!;

    public virtual MagicSchool School { get; set; } = null!;

    public virtual ICollection<SpellDamage> SpellDamages { get; set; } = new List<SpellDamage>();
}

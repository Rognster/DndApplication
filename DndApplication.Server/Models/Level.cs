using System;
using System.Collections.Generic;

namespace DndApplication.Server.Models;

public partial class Level
{
    public int Id { get; set; }

    public int ClassLevel { get; set; }

    public int AbilityScoreBonuses { get; set; }

    public int ProfBonus { get; set; }

    public int ClassId { get; set; }

    public string Index { get; set; } = null!;

    public string Url { get; set; } = null!;

    public virtual Class Class { get; set; } = null!;

    public virtual ICollection<ClassSpecific> ClassSpecifics { get; set; } = new List<ClassSpecific>();

    public virtual ICollection<LevelFeature> LevelFeatures { get; set; } = new List<LevelFeature>();

    public virtual ICollection<SpellcastingLevel> SpellcastingLevels { get; set; } = new List<SpellcastingLevel>();
}

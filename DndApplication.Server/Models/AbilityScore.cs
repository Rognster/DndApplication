using System;
using System.Collections.Generic;

namespace DndApplication.Server.Models;

public partial class AbilityScore
{
    public string IndexId { get; set; } = null!;

    public string Name { get; set; } = null!;

    public string FullName { get; set; } = null!;

    public string Description { get; set; } = null!;

    public string Url { get; set; } = null!;

    public int? Id { get; set; }

    public virtual ICollection<ClassSavingThrow> ClassSavingThrows { get; set; } = new List<ClassSavingThrow>();

    public virtual ICollection<MonsterSavingThrow> MonsterSavingThrows { get; set; } = new List<MonsterSavingThrow>();

    public virtual ICollection<RaceAbilityBonus> RaceAbilityBonuses { get; set; } = new List<RaceAbilityBonus>();

    public virtual ICollection<Skill> Skills { get; set; } = new List<Skill>();
}

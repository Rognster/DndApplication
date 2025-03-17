using System;
using System.Collections.Generic;

namespace DndApplication.Server.Models;

public partial class Skill
{
    public int Id { get; set; }

    public string? AbilityScoreIndex { get; set; }

    public string Name { get; set; } = null!;

    public string SkillIndex { get; set; } = null!;

    public string Url { get; set; } = null!;

    public string? Description { get; set; }

    public virtual AbilityScore? AbilityScoreIndexNavigation { get; set; }

    public virtual ICollection<ClassProficiencySkill> ClassProficiencySkills { get; set; } = new List<ClassProficiencySkill>();

    public virtual ICollection<MonsterSkill> MonsterSkills { get; set; } = new List<MonsterSkill>();

    public virtual ICollection<RaceSkill> RaceSkills { get; set; } = new List<RaceSkill>();
}

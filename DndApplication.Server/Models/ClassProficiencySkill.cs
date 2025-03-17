using System;
using System.Collections.Generic;

namespace DndApplication.Server.Models;

public partial class ClassProficiencySkill
{
    public int Id { get; set; }

    public int ProficiencyOptionId { get; set; }

    public int SkillId { get; set; }

    public virtual ClassProficiencyOption ProficiencyOption { get; set; } = null!;

    public virtual Skill Skill { get; set; } = null!;
}

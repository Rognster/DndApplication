using System;
using System.Collections.Generic;

namespace DndApplication.Server.Models;

public partial class ClassProficiencyOption
{
    public int Id { get; set; }

    public int ClassId { get; set; }

    public string Description { get; set; } = null!;

    public int Choose { get; set; }

    public virtual Class Class { get; set; } = null!;

    public virtual ICollection<ClassProficiencySkill> ClassProficiencySkills { get; set; } = new List<ClassProficiencySkill>();
}

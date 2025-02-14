using System;
using System.Collections.Generic;

namespace DndApplication.Server.Models;

public partial class RaceSkill
{
    public int Id { get; set; }

    public int RaceId { get; set; }

    public int SkillId { get; set; }

    public virtual Race Race { get; set; } = null!;

    public virtual Skill Skill { get; set; } = null!;
}

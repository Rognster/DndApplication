using System;
using System.Collections.Generic;

namespace DndApplication.Server.Models;

public partial class RaceProficiency
{
    public int Id { get; set; }

    public int RaceId { get; set; }

    public int ProficiencyId { get; set; }

    public virtual Proficiency Proficiency { get; set; } = null!;

    public virtual Race Race { get; set; } = null!;
}

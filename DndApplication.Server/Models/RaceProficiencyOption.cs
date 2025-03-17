using System;
using System.Collections.Generic;

namespace DndApplication.Server.Models;

public partial class RaceProficiencyOption
{
    public int Id { get; set; }

    public int RaceId { get; set; }

    public string? Description { get; set; }

    public int Choose { get; set; }

    public virtual Race Race { get; set; } = null!;
}

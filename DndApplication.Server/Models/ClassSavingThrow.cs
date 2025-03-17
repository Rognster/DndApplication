using System;
using System.Collections.Generic;

namespace DndApplication.Server.Models;

public partial class ClassSavingThrow
{
    public int Id { get; set; }

    public int ClassId { get; set; }

    public string AbilityScoreIndexId { get; set; } = null!;

    public virtual AbilityScore AbilityScoreIndex { get; set; } = null!;

    public virtual Class Class { get; set; } = null!;
}

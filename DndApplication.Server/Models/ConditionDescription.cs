using System;
using System.Collections.Generic;

namespace DndApplication.Server.Models;

public partial class ConditionDescription
{
    public int Id { get; set; }

    public int ConditionId { get; set; }

    public string Description { get; set; } = null!;

    public virtual Condition Condition { get; set; } = null!;
}

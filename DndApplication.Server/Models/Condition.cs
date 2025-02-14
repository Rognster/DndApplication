using System;
using System.Collections.Generic;

namespace DndApplication.Server.Models;

public partial class Condition
{
    public int Id { get; set; }

    public string Index { get; set; } = null!;

    public string Name { get; set; } = null!;

    public string Url { get; set; } = null!;

    public virtual ICollection<ConditionDescription> ConditionDescriptions { get; set; } = new List<ConditionDescription>();
}

using System;
using System.Collections.Generic;

namespace DndApplication.Server.Models;

public partial class RuleSubsection
{
    public int Id { get; set; }

    public int RuleId { get; set; }

    public string Index { get; set; } = null!;

    public string Name { get; set; } = null!;

    public string Url { get; set; } = null!;

    public virtual Rule Rule { get; set; } = null!;
}

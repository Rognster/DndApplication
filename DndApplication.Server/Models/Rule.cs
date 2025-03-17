using System;
using System.Collections.Generic;

namespace DndApplication.Server.Models;

public partial class Rule
{
    public int Id { get; set; }

    public string Index { get; set; } = null!;

    public string Name { get; set; } = null!;

    public string Description { get; set; } = null!;

    public string Url { get; set; } = null!;

    public virtual ICollection<RuleSubsection> RuleSubsections { get; set; } = new List<RuleSubsection>();
}

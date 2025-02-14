using System;
using System.Collections.Generic;

namespace DndApplication.Server.Models;

public partial class RuleSection
{
    public int Id { get; set; }

    public string RuleIndex { get; set; } = null!;

    public string Name { get; set; } = null!;

    public string Description { get; set; } = null!;

    public string Url { get; set; } = null!;
}

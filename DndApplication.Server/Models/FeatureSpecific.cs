using System;
using System.Collections.Generic;

namespace DndApplication.Server.Models;

public partial class FeatureSpecific
{
    public int Id { get; set; }

    public int FeatureId { get; set; }

    public string? OptionType { get; set; }

    public int? Choose { get; set; }

    public string? Type { get; set; }

    public virtual Feature Feature { get; set; } = null!;
}

using System;
using System.Collections.Generic;

namespace DndApplication.Server.Models;

public partial class FeatureMapping
{
    public int Id { get; set; }

    public int ParentFeatureId { get; set; }

    public int ChildFeatureId { get; set; }

    public virtual Feature ChildFeature { get; set; } = null!;

    public virtual Feature ParentFeature { get; set; } = null!;
}

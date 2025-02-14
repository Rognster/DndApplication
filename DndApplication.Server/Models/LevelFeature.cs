using System;
using System.Collections.Generic;

namespace DndApplication.Server.Models;

public partial class LevelFeature
{
    public int Id { get; set; }

    public int LevelId { get; set; }

    public int FeatureId { get; set; }

    public virtual Feature Feature { get; set; } = null!;

    public virtual Level Level { get; set; } = null!;
}

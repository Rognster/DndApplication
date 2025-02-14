using System;
using System.Collections.Generic;

namespace DndApplication.Server.Models;

public partial class Feat
{
    public int Id { get; set; }

    public string Index { get; set; } = null!;

    public string Name { get; set; } = null!;

    public string Url { get; set; } = null!;

    public virtual ICollection<FeatDescription> FeatDescriptions { get; set; } = new List<FeatDescription>();

    public virtual ICollection<Prerequisite> Prerequisites { get; set; } = new List<Prerequisite>();
}

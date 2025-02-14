using System;
using System.Collections.Generic;

namespace DndApplication.Server.Models;

public partial class Subclass
{
    public int Id { get; set; }

    public int ClassId { get; set; }

    public string SubclassIndex { get; set; } = null!;

    public string SubclassName { get; set; } = null!;

    public string SubclassUrl { get; set; } = null!;

    public string? Description { get; set; }

    public virtual Class Class { get; set; } = null!;

    public virtual ICollection<Feature> Features { get; set; } = new List<Feature>();
}

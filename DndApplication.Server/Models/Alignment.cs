using System;
using System.Collections.Generic;

namespace DndApplication.Server.Models;

public partial class Alignment
{
    public string IndexId { get; set; } = null!;

    public string Name { get; set; } = null!;

    public string Abbreviation { get; set; } = null!;

    public string Description { get; set; } = null!;

    public string Url { get; set; } = null!;

    public virtual ICollection<Monster> Monsters { get; set; } = new List<Monster>();
}

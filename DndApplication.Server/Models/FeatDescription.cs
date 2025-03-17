using System;
using System.Collections.Generic;

namespace DndApplication.Server.Models;

public partial class FeatDescription
{
    public int Id { get; set; }

    public int FeatId { get; set; }

    public string Description { get; set; } = null!;

    public virtual Feat Feat { get; set; } = null!;
}

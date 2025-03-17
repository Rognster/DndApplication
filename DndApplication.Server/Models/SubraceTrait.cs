using System;
using System.Collections.Generic;

namespace DndApplication.Server.Models;

public partial class SubraceTrait
{
    public int Id { get; set; }

    public int TraitId { get; set; }

    public int SubraceId { get; set; }

    public virtual Subrace Subrace { get; set; } = null!;

    public virtual Trait Trait { get; set; } = null!;
}

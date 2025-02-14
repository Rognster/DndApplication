using System;
using System.Collections.Generic;

namespace DndApplication.Server.Models;

public partial class Subrace
{
    public int Id { get; set; }

    public string Index { get; set; } = null!;

    public string Name { get; set; } = null!;

    public int RaceId { get; set; }

    public string Url { get; set; } = null!;

    public string? Description { get; set; }

    public virtual Race Race { get; set; } = null!;

    public virtual ICollection<SubraceProficiency> SubraceProficiencies { get; set; } = new List<SubraceProficiency>();

    public virtual ICollection<SubraceTrait> SubraceTraits { get; set; } = new List<SubraceTrait>();
}

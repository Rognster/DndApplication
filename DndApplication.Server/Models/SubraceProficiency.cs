using System;
using System.Collections.Generic;

namespace DndApplication.Server.Models;

public partial class SubraceProficiency
{
    public int Id { get; set; }

    public int SubraceId { get; set; }

    public int ProficiencyId { get; set; }

    public virtual Proficiency Proficiency { get; set; } = null!;

    public virtual Subrace Subrace { get; set; } = null!;
}

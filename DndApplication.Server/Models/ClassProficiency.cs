using System;
using System.Collections.Generic;

namespace DndApplication.Server.Models;

public partial class ClassProficiency
{
    public int Id { get; set; }

    public int ClassId { get; set; }

    public string ProficiencyUrl { get; set; } = null!;

    public int? ProficiencyId { get; set; }

    public virtual Class Class { get; set; } = null!;

    public virtual Proficiency? Proficiency { get; set; }
}

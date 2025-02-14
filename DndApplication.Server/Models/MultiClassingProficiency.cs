using System;
using System.Collections.Generic;

namespace DndApplication.Server.Models;

public partial class MultiClassingProficiency
{
    public int ClassId { get; set; }

    public string ProficiencyIndex { get; set; } = null!;

    public string ProficiencyName { get; set; } = null!;

    public string ProficiencyUrl { get; set; } = null!;

    public virtual Class Class { get; set; } = null!;
}

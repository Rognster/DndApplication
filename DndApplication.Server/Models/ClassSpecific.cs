using System;
using System.Collections.Generic;

namespace DndApplication.Server.Models;

public partial class ClassSpecific
{
    public int Id { get; set; }

    public int LevelId { get; set; }

    public string KeyName { get; set; } = null!;

    public string Value { get; set; } = null!;

    public int? Count { get; set; }

    public virtual Level Level { get; set; } = null!;
}

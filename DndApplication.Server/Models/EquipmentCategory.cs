using System;
using System.Collections.Generic;

namespace DndApplication.Server.Models;

public partial class EquipmentCategory
{
    public int Id { get; set; }

    public string Index { get; set; } = null!;

    public string Name { get; set; } = null!;

    public string? Url { get; set; }

    public virtual ICollection<MagicItem> MagicItems { get; set; } = new List<MagicItem>();

    public virtual ICollection<Equipment> Equipment { get; set; } = new List<Equipment>();
}

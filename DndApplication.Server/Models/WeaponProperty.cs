using System;
using System.Collections.Generic;

namespace DndApplication.Server.Models;

public partial class WeaponProperty
{
    public int Id { get; set; }

    public string Index { get; set; } = null!;

    public string Name { get; set; } = null!;

    public string Url { get; set; } = null!;

    public virtual ICollection<WeaponPropertyDescription> WeaponPropertyDescriptions { get; set; } = new List<WeaponPropertyDescription>();

    public virtual ICollection<Equipment> Equipment { get; set; } = new List<Equipment>();
}

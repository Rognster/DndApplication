using System;
using System.Collections.Generic;

namespace DndApplication.Server.Models;

public partial class WeaponPropertyDescription
{
    public int Id { get; set; }

    public int WeaponPropertyId { get; set; }

    public string Description { get; set; } = null!;

    public virtual WeaponProperty WeaponProperty { get; set; } = null!;
}

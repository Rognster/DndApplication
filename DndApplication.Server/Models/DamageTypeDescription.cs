using System;
using System.Collections.Generic;

namespace DndApplication.Server.Models;

public partial class DamageTypeDescription
{
    public int Id { get; set; }

    public int DamageTypeId { get; set; }

    public string Description { get; set; } = null!;

    public virtual DamageType DamageType { get; set; } = null!;
}

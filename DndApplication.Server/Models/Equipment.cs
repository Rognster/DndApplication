using System;
using System.Collections.Generic;

namespace DndApplication.Server.Models;

public partial class Equipment
{
    public int Id { get; set; }

    public string Index { get; set; } = null!;

    public string Name { get; set; } = null!;

    public string? Url { get; set; }

    public string? WeaponCategory { get; set; }

    public string? WeaponRange { get; set; }

    public string? CategoryRange { get; set; }

    public int? CostQuantity { get; set; }

    public string? CostUnit { get; set; }

    public string? DamageDice { get; set; }

    public string? DamageType { get; set; }

    public int? RangeNormal { get; set; }

    public int? RangeLong { get; set; }

    public int? Weight { get; set; }

    public int? EquipmentCategoryId { get; set; }

    public virtual ICollection<EquipmentCategory> Categories { get; set; } = new List<EquipmentCategory>();

    public virtual ICollection<WeaponProperty> Properties { get; set; } = new List<WeaponProperty>();
}

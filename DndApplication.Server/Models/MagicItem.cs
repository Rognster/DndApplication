using System;
using System.Collections.Generic;

namespace DndApplication.Server.Models;

public partial class MagicItem
{
    public int Id { get; set; }

    public string Index { get; set; } = null!;

    public string Name { get; set; } = null!;

    public int EquipmentCategoryId { get; set; }

    public string Rarity { get; set; } = null!;

    public bool Variant { get; set; }

    public string Description { get; set; } = null!;

    public string? Image { get; set; }

    public string Url { get; set; } = null!;

    public virtual EquipmentCategory EquipmentCategory { get; set; } = null!;

    public virtual ICollection<MagicItemVariant> MagicItemVariantParentMagicItems { get; set; } = new List<MagicItemVariant>();

    public virtual ICollection<MagicItemVariant> MagicItemVariantVariantMagicItems { get; set; } = new List<MagicItemVariant>();
}

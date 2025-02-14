using System;
using System.Collections.Generic;

namespace DndApplication.Server.Models;

public partial class MagicItemVariant
{
    public int Id { get; set; }

    public int ParentMagicItemId { get; set; }

    public int VariantMagicItemId { get; set; }

    public virtual MagicItem ParentMagicItem { get; set; } = null!;

    public virtual MagicItem VariantMagicItem { get; set; } = null!;
}

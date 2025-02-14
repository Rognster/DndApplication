using System;
using System.Collections.Generic;

namespace DndApplication.Server.Models;

public partial class EquipmentOptionDetail
{
    public int Id { get; set; }

    public int OptionId { get; set; }

    public string OptionType { get; set; } = null!;

    public string? ItemIndex { get; set; }

    public string? ItemName { get; set; }

    public string? ItemUrl { get; set; }

    public int? Quantity { get; set; }

    public virtual StartingEquipmentOption Option { get; set; } = null!;
}

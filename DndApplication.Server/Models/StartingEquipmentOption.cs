using System;
using System.Collections.Generic;

namespace DndApplication.Server.Models;

public partial class StartingEquipmentOption
{
    public int Id { get; set; }

    public int ClassId { get; set; }

    public string Description { get; set; } = null!;

    public int ChooseCount { get; set; }

    public string? OptionType { get; set; }

    public virtual Class Class { get; set; } = null!;

    public virtual ICollection<EquipmentOptionDetail> EquipmentOptionDetails { get; set; } = new List<EquipmentOptionDetail>();
}

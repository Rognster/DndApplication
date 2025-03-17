using System;
using System.Collections.Generic;

namespace DndApplication.Server.Models;

public partial class StartingEquipment
{
    public int Id { get; set; }

    public int ClassId { get; set; }

    public string EquipmentIndex { get; set; } = null!;

    public string EquipmentName { get; set; } = null!;

    public string EquipmentUrl { get; set; } = null!;

    public int Quantity { get; set; }

    public virtual Class Class { get; set; } = null!;
}

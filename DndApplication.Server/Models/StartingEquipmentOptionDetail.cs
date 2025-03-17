using System;
using System.Collections.Generic;

namespace DndApplication.Server.Models;

public partial class StartingEquipmentOptionDetail
{
    public int ClassId { get; set; }

    public int OptionId { get; set; }

    public string OptionIndex { get; set; } = null!;

    public string OptionName { get; set; } = null!;

    public string OptionUrl { get; set; } = null!;

    public int? Quantity { get; set; }
}

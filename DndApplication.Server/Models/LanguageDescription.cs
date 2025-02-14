using System;
using System.Collections.Generic;

namespace DndApplication.Server.Models;

public partial class LanguageDescription
{
    public int Id { get; set; }

    public int LanguageId { get; set; }

    public string Description { get; set; } = null!;

    public virtual Language Language { get; set; } = null!;
}

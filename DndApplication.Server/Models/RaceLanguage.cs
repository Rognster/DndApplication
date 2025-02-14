using System;
using System.Collections.Generic;

namespace DndApplication.Server.Models;

public partial class RaceLanguage
{
    public int Id { get; set; }

    public int RaceId { get; set; }

    public int LanguageId { get; set; }

    public virtual Language Language { get; set; } = null!;

    public virtual Race Race { get; set; } = null!;
}

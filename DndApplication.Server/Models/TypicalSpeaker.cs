using System;
using System.Collections.Generic;

namespace DndApplication.Server.Models;

public partial class TypicalSpeaker
{
    public int Id { get; set; }

    public int LanguageId { get; set; }

    public string Speaker { get; set; } = null!;

    public virtual Language Language { get; set; } = null!;
}

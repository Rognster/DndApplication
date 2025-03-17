using System;
using System.Collections.Generic;

namespace DndApplication.Server.Models;

public partial class Language
{
    public int Id { get; set; }

    public string Index { get; set; } = null!;

    public string Name { get; set; } = null!;

    public string Type { get; set; } = null!;

    public string? Script { get; set; }

    public string Url { get; set; } = null!;

    public virtual ICollection<LanguageDescription> LanguageDescriptions { get; set; } = new List<LanguageDescription>();

    public virtual ICollection<RaceLanguage> RaceLanguages { get; set; } = new List<RaceLanguage>();

    public virtual ICollection<TypicalSpeaker> TypicalSpeakers { get; set; } = new List<TypicalSpeaker>();

    public virtual ICollection<Monster> Monsters { get; set; } = new List<Monster>();
}

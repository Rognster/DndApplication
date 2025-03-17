using System;
using System.Collections.Generic;

namespace DndApplication.Server.Models;

public partial class Race
{
    public int Id { get; set; }

    public string Index { get; set; } = null!;

    public string Name { get; set; } = null!;

    public int Speed { get; set; }

    public string? Alignment { get; set; }

    public string? Age { get; set; }

    public string Size { get; set; } = null!;

    public string? SizeDescription { get; set; }

    public string? LanguageDesc { get; set; }

    public string Url { get; set; } = null!;

    public virtual ICollection<RaceAbilityBonusOption> RaceAbilityBonusOptions { get; set; } = new List<RaceAbilityBonusOption>();

    public virtual ICollection<RaceAbilityBonus> RaceAbilityBonuses { get; set; } = new List<RaceAbilityBonus>();

    public virtual ICollection<RaceLanguageOption> RaceLanguageOptions { get; set; } = new List<RaceLanguageOption>();

    public virtual ICollection<RaceLanguage> RaceLanguages { get; set; } = new List<RaceLanguage>();

    public virtual ICollection<RaceProficiency> RaceProficiencies { get; set; } = new List<RaceProficiency>();

    public virtual ICollection<RaceProficiencyOption> RaceProficiencyOptions { get; set; } = new List<RaceProficiencyOption>();

    public virtual ICollection<RaceSkill> RaceSkills { get; set; } = new List<RaceSkill>();

    public virtual ICollection<RaceTrait> RaceTraits { get; set; } = new List<RaceTrait>();

    public virtual ICollection<Subrace> Subraces { get; set; } = new List<Subrace>();
}

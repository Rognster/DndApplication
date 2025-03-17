using System;
using System.Collections.Generic;

namespace DndApplication.Server.Models;

public partial class Monster
{
    public int Id { get; set; }

    public string Index { get; set; } = null!;

    public string Name { get; set; } = null!;

    public string Size { get; set; } = null!;

    public string Type { get; set; } = null!;

    public string? Subtype { get; set; }

    public string? Alignment { get; set; }

    public string? AlignmentId { get; set; }

    public int ArmorClass { get; set; }

    public int HitPoints { get; set; }

    public string HitDice { get; set; } = null!;

    public string? HitPointsRoll { get; set; }

    public string Speed { get; set; } = null!;

    public int Strength { get; set; }

    public int Dexterity { get; set; }

    public int Constitution { get; set; }

    public int Intelligence { get; set; }

    public int Wisdom { get; set; }

    public int Charisma { get; set; }

    public double ChallengeRating { get; set; }

    public int ProficiencyBonus { get; set; }

    public int Xp { get; set; }

    public string? SpecialAbilities { get; set; }

    public string? Actions { get; set; }

    public string Url { get; set; } = null!;

    public virtual Alignment? AlignmentNavigation { get; set; }

    public virtual ICollection<MonsterSavingThrow> MonsterSavingThrows { get; set; } = new List<MonsterSavingThrow>();

    public virtual ICollection<MonsterSkill> MonsterSkills { get; set; } = new List<MonsterSkill>();

    public virtual ICollection<Language> Languages { get; set; } = new List<Language>();
}

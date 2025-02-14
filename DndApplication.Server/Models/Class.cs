using System;
using System.Collections.Generic;

namespace DndApplication.Server.Models;

public partial class Class
{
    public int Id { get; set; }

    public string IndexId { get; set; } = null!;

    public string Name { get; set; } = null!;

    public int HitDie { get; set; }

    public string? ClassLevelsUrl { get; set; }

    public string? MultiClassingPrerequisite { get; set; }

    public string Url { get; set; } = null!;

    public virtual ICollection<ClassProficiency> ClassProficiencies { get; set; } = new List<ClassProficiency>();

    public virtual ICollection<ClassProficiencyOption> ClassProficiencyOptions { get; set; } = new List<ClassProficiencyOption>();

    public virtual ICollection<ClassSavingThrow> ClassSavingThrows { get; set; } = new List<ClassSavingThrow>();

    public virtual ICollection<Feature> Features { get; set; } = new List<Feature>();

    public virtual ICollection<Level> Levels { get; set; } = new List<Level>();

    public virtual ICollection<MultiClassingProficiency> MultiClassingProficiencies { get; set; } = new List<MultiClassingProficiency>();

    public virtual ICollection<MultiClassing> MultiClassings { get; set; } = new List<MultiClassing>();

    public virtual ICollection<SavingThrow> SavingThrows { get; set; } = new List<SavingThrow>();

    public virtual ICollection<StartingEquipmentOption> StartingEquipmentOptions { get; set; } = new List<StartingEquipmentOption>();

    public virtual ICollection<StartingEquipment> StartingEquipments { get; set; } = new List<StartingEquipment>();

    public virtual ICollection<Subclass> Subclasses { get; set; } = new List<Subclass>();
}

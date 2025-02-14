using System;
using System.Collections.Generic;

namespace DndApplication.Server.Models;

public partial class Proficiency
{
    public int Id { get; set; }

    public string Index { get; set; } = null!;

    public string Type { get; set; } = null!;

    public string Name { get; set; } = null!;

    public string Url { get; set; } = null!;

    public string? ReferenceIndex { get; set; }

    public string? ReferenceName { get; set; }

    public string? ReferenceUrl { get; set; }

    public virtual ICollection<ClassProficiency> ClassProficiencies { get; set; } = new List<ClassProficiency>();

    public virtual ICollection<RaceProficiency> RaceProficiencies { get; set; } = new List<RaceProficiency>();

    public virtual ICollection<SubraceProficiency> SubraceProficiencies { get; set; } = new List<SubraceProficiency>();
}

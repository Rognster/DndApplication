using System;
using System.Collections.Generic;

namespace DndApplication.Server.Models;

public partial class SpellDamage
{
    public int Id { get; set; }

    public int SpellId { get; set; }

    public int DamageTypeId { get; set; }

    public string? DamageAtSlotLevel { get; set; }

    public string? DamageAtCharacterLevel { get; set; }

    public virtual DamageType DamageType { get; set; } = null!;

    public virtual Spell Spell { get; set; } = null!;
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DndApplication.Server.Dtos
{
    public class SpellDto
    {
        public int Id { get; set; }
        public string SpellIndex { get; set; } = null!;
        public string Name { get; set; } = null!;
        public string Description { get; set; } = null!;
        public string? HigherLevel { get; set; }
        public string Range { get; set; } = null!;
        public string Components { get; set; } = null!;
        public string? Material { get; set; }
        public bool Ritual { get; set; }
        public string Duration { get; set; } = null!;
        public bool Concentration { get; set; }
        public string CastingTime { get; set; } = null!;
        public int Level { get; set; }
        public string School { get; set; } = null!;
        public string Url { get; set; } = null!;
        public IEnumerable<SpellDamageDto>? Damage { get; set; }
    }

    public class SpellDamageDto
    {
        public string DamageType { get; set; } = null!;
        public string? DamageAtSlotLevel { get; set; }
        public string? DamageAtCharacterLevel { get; set; }
    }
}

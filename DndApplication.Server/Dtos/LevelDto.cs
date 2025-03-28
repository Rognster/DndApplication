namespace DndApplication.Server.Dtos
{
    public class LevelDto
    {
        public int Id { get; set; }
        public int ClassLevel { get; set; } // Represents the actual level (1, 2, 3...)
        public int AbilityScoreBonuses { get; set; }
        public int ProfBonus { get; set; }

        public IEnumerable<FeatureDto> Features { get; set; } = new List<FeatureDto>();
        public IEnumerable<SpellDto> Spells { get; set; } = new List<SpellDto>();
    }

    public class FeatureDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string Description { get; set; } = null!;
    }

    public class SpellDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string Description { get; set; } = null!;
        public string Url { get; set; } = null!;
    }
}

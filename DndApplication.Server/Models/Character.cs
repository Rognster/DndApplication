using System.Collections.Generic;

namespace DndApplication.Server.Models
{
    public class Character
    {
        public int Id { get; set; }

        public string Name { get; set; } = string.Empty;

        public string? Nickname { get; set; }

        public string? Player { get; set; }

        // Properties as strings and lists of strings
        public List<int> AbilityScores { get; set; } = new List<int>();

        public string? Alignment { get; set; }

        public string? Background { get; set; }

        public string? Class { get; set; }

        public List<string>? Equipments { get; set; }

        public List<string>? Feats { get; set; }

        public List<string>? Features { get; set; }

        public List<string>? Languages { get; set; }

        public List<string>? Proficiencies { get; set; }

        public string? Race { get; set; }

        public List<string>? Skills { get; set; }

        public List<string>? Spells { get; set; }

        public string? Subclass { get; set; }

        public string? Subrace { get; set; }

        public List<string>? Traits { get; set; }
    }
}

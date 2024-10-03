using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace DndApplication.Server.Models
{
    public class CharacterStat
    {
        public int Strength { get; set; }
        public int Dexterity { get; set; }
        public int Constitution { get; set; }
        public int Intelligence { get; set; }
        public int Wisdom { get; set; }
        public int Charisma { get; set; }
    }

    public class Equipment
    {
        public int Id { get; set; } // Primary key for Equipment
        public string ItemId { get; set; } // Item ID from the D&D API

        // Foreign key for Character
        public int CharacterId { get; set; }

        [JsonIgnore] // Prevents circular reference during serialization
        public Character? Character { get; set; }
    }

    public class Character
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public CharacterStat Stats { get; set; }
        public List<Equipment> Equipments { get; set; } = new List<Equipment>();
    }
}

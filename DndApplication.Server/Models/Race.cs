namespace DndApplication.Server.Models
{
    public class Race
    {
        public int Id { get; set; }
        public string? Index { get; set; } // Name of the race (e.g., "Elf")
        public string? Name { get; set; } // Optional description of the race

        public string? Url { get; set; } // Optional description of the race
    }
}

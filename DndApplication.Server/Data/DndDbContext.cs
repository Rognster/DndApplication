using Microsoft.EntityFrameworkCore;
using DndApplication.Server.Models;

namespace DndApplication.Server.Data
{
    public class DndDbContext : DbContext
    {
        public DndDbContext(DbContextOptions<DndDbContext> options) : base(options) { }

        // Design-time DbContext constructor
        public DndDbContext() { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                // This connection string is used at design time
                optionsBuilder.UseSqlite("Data Source=dndDatabase.db");
            }
        }

        public DbSet<Character> Characters { get; set; }
        public DbSet<Equipment> Equipments { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configure CharacterStat as an owned type of Character
            modelBuilder.Entity<Character>().OwnsOne(c => c.Stats);

            // Configure Equipment with a primary key and relationship to Character
            modelBuilder.Entity<Equipment>().HasKey(e => e.Id);
            modelBuilder.Entity<Equipment>()
                        .HasOne(e => e.Character)
                        .WithMany(c => c.Equipments)
                        .HasForeignKey(e => e.CharacterId);

            // Seed data for Characters
            modelBuilder.Entity<Character>().HasData(
                new Character
                {
                    Id = 1,
                    Name = "Stefan"
                },
                new Character
                {
                    Id = 2,
                    Name = "Olle"
                }
            );

            // Seed data for CharacterStat as part of Character
            modelBuilder.Entity<Character>().OwnsOne(c => c.Stats).HasData(
                new { CharacterId = 1, Strength = 15, Dexterity = 12, Constitution = 14, Intelligence = 10, Wisdom = 11, Charisma = 10 },
                new { CharacterId = 2, Strength = 16, Dexterity = 13, Constitution = 15, Intelligence = 11, Wisdom = 12, Charisma = 9 }
            );

            // Seed data for Equipments
            modelBuilder.Entity<Equipment>().HasData(
                new Equipment { Id = 1, ItemId = "sword", CharacterId = 1 },
                new Equipment { Id = 2, ItemId = "shield", CharacterId = 1 },
                new Equipment { Id = 3, ItemId = "axe", CharacterId = 2 }
            );
        }
    }
}

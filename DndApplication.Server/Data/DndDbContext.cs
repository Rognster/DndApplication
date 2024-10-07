using DndApplication.Server.Models;
using Microsoft.EntityFrameworkCore;
using System.Data;
using System.Diagnostics;
using System.Security.Claims;
using System.Threading;

namespace DndApplication.Server.Data
{
    public class DndDbContext : DbContext
    {
        public DbSet<Character> Characters { get; set; }
        public DbSet<AbilityScore> AbilityScores { get; set; }
        public DbSet<Alignment> Alignments { get; set; }
        public DbSet<Background> Backgrounds { get; set; }
        public DbSet<Class> Classes { get; set; }
        public DbSet<Condition> Conditions { get; set; }
        public DbSet<DamageType> DamageTypes { get; set; }
        public DbSet<Equipment> Equipments { get; set; }
        public DbSet<EquipmentCategory> EquipmentCategories { get; set; }
        public DbSet<Feat> Feats { get; set; }
        public DbSet<Feature> Features { get; set; }
        public DbSet<Language> Languages { get; set; }
        public DbSet<MagicItem> MagicItems { get; set; }
        public DbSet<MagicSchool> MagicSchools { get; set; }
        public DbSet<Monster> Monsters { get; set; }
        public DbSet<Proficiency> Proficiencies { get; set; }
        public DbSet<Race> Races { get; set; }
        public DbSet<RuleSection> RuleSections { get; set; }
        //public DbSet<Rule> Rules { get; set; }
        public DbSet<Skill> Skills { get; set; }
        public DbSet<Spell> Spells { get; set; }
        public DbSet<Subclass> Subclasses { get; set; }
        public DbSet<Subrace> Subraces { get; set; }
        public DbSet<Trait> Traits { get; set; }
        public DbSet<WeaponProperty> WeaponProperties { get; set; }

        public DndDbContext(DbContextOptions<DndDbContext> options) : base(options)
        {
        }

    }
}

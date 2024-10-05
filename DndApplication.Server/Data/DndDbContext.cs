using Microsoft.EntityFrameworkCore;

namespace DndApplication.Server.Data
{
    public class DndDbContext : DbContext
    {
        public DbSet<Character> Characters { get; set; }

        public DndDbContext(DbContextOptions<DndDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Optional: Configure entity properties or constraints here
            modelBuilder.Entity<Character>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Name)
                      .IsRequired()
                      .HasMaxLength(100); // Example constraint
                entity.Property(e => e.Nickname)
                      .HasMaxLength(100); // Example constraint
            });
        }
    }
}

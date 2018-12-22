using Microsoft.EntityFrameworkCore;

namespace NTUEvents.Models
{
    public class NtuEventsContext : DbContext
    {
        public NtuEventsContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CcaMembership>()
             .HasKey(e => new { e.UserId, e.CcaId });
            modelBuilder.Entity<EventParticipation>()
             .HasKey(e => new { e.UserId, e.EventId });
        }

        public DbSet<Cca> Ccas { get; set; }
        public DbSet<CcaMembership> CcaMemberships { get; set; }
        public DbSet<Event> Events { get; set; }
        public DbSet<EventParticipation> EventParticipations { get; set; }
        public DbSet<User> Users { get; set; }
    }
}

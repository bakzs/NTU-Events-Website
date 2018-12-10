using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace NTUEvents.Models
{
    public partial class NtuEventsDbContext : DbContext
    {
        public NtuEventsDbContext()
        {
        }

        public NtuEventsDbContext(DbContextOptions<NtuEventsDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Cca> Cca { get; set; }
        public virtual DbSet<Ccamembership> Ccamembership { get; set; }
        public virtual DbSet<Event> Event { get; set; }
        public virtual DbSet<Eventreg> Eventreg { get; set; }
        public virtual DbSet<User> User { get; set; }
        public virtual DbSet<Userprofile> Userprofile { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                #warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseMySql("server=localhost;port=3306;database=ntuevents;user=root;password=test1234!");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Cca>(entity =>
            {
                entity.ToTable("cca");

                entity.HasIndex(e => e.UserIdCcaFk)
                    .HasName("UserId_idx");

                entity.Property(e => e.CcaId).HasColumnType("int(11)");

                entity.Property(e => e.CcaType).HasColumnType("varchar(45)");

                entity.Property(e => e.Contact).HasColumnType("varchar(45)");

                entity.Property(e => e.Description).HasColumnType("varchar(1024)");

                entity.Property(e => e.Schedule).HasColumnType("varchar(45)");

                entity.Property(e => e.UserIdCcaFk)
                    .HasColumnName("UserId_Cca_FK")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Venue).HasColumnType("varchar(45)");

                entity.HasOne(d => d.UserIdCcaFkNavigation)
                    .WithMany(p => p.Cca)
                    .HasForeignKey(d => d.UserIdCcaFk)
                    .HasConstraintName("UserId_Cca_FK");
            });

            modelBuilder.Entity<Ccamembership>(entity =>
            {
                entity.ToTable("ccamembership");

                entity.HasIndex(e => e.CcaIdCcaMemFk)
                    .HasName("CcaId_idx");

                entity.HasIndex(e => e.UserIdCcaMemFk)
                    .HasName("UserId_idx");

                entity.Property(e => e.CcaMembershipId).HasColumnType("int(11)");

                entity.Property(e => e.CcaIdCcaMemFk)
                    .HasColumnName("CcaId_CcaMem_FK")
                    .HasColumnType("int(11)");

                entity.Property(e => e.CreatedBy).HasColumnType("int(11)");

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.IsDeleted).HasColumnType("bit(1)");

                entity.Property(e => e.UpdatedBy).HasColumnType("int(11)");

                entity.Property(e => e.UpdatedDate).HasColumnType("datetime");

                entity.Property(e => e.UserIdCcaMemFk)
                    .HasColumnName("UserId_CcaMem_FK")
                    .HasColumnType("int(11)");

                entity.HasOne(d => d.CcaIdCcaMemFkNavigation)
                    .WithMany(p => p.Ccamembership)
                    .HasForeignKey(d => d.CcaIdCcaMemFk)
                    .HasConstraintName("CcaId_CcaMem_FK");

                entity.HasOne(d => d.UserIdCcaMemFkNavigation)
                    .WithMany(p => p.Ccamembership)
                    .HasForeignKey(d => d.UserIdCcaMemFk)
                    .HasConstraintName("UserId_CcaMem_FK");
            });

            modelBuilder.Entity<Event>(entity =>
            {
                entity.ToTable("event");

                entity.HasIndex(e => e.CcaidEventFk)
                    .HasName("CcaId_Event_Fk_idx");

                entity.Property(e => e.EventId).HasColumnType("int(11)");

                entity.Property(e => e.CcaidEventFk)
                    .HasColumnName("CCAId_Event_FK")
                    .HasColumnType("int(11)");

                entity.Property(e => e.CreatedBy).HasColumnType("int(11)");

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.Description).HasColumnType("varchar(1024)");

                entity.Property(e => e.EndDate).HasColumnType("datetime");

                entity.Property(e => e.IsDeleted).HasColumnType("bit(1)");

                entity.Property(e => e.Quota).HasColumnType("int(11)");

                entity.Property(e => e.StartDate).HasColumnType("datetime");

                entity.Property(e => e.Title).HasColumnType("varchar(45)");

                entity.Property(e => e.Type).HasColumnType("varchar(45)");

                entity.Property(e => e.UpdatedBy).HasColumnType("int(11)");

                entity.Property(e => e.UpdatedDate).HasColumnType("datetime");

                entity.Property(e => e.Venue).HasColumnType("varchar(45)");

                entity.HasOne(d => d.CcaidEventFkNavigation)
                    .WithMany(p => p.Event)
                    .HasForeignKey(d => d.CcaidEventFk)
                    .HasConstraintName("CcaId_Event_Fk");
            });

            modelBuilder.Entity<Eventreg>(entity =>
            {
                entity.ToTable("eventreg");

                entity.HasIndex(e => e.EventidEventregFk)
                    .HasName("EventId_idx");

                entity.HasIndex(e => e.UserIdEventregFk)
                    .HasName("UserId_idx");

                entity.Property(e => e.EventregId).HasColumnType("int(11)");

                entity.Property(e => e.CreatedBy).HasColumnType("int(11)");

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.EventidEventregFk)
                    .HasColumnName("Eventid_Eventreg_FK")
                    .HasColumnType("int(11)");

                entity.Property(e => e.IsDeleted)
                    .HasColumnName("isDeleted")
                    .HasColumnType("bit(1)");

                entity.Property(e => e.UserIdEventregFk)
                    .HasColumnName("UserId_Eventreg_FK")
                    .HasColumnType("int(11)");

                entity.HasOne(d => d.EventidEventregFkNavigation)
                    .WithMany(p => p.Eventreg)
                    .HasForeignKey(d => d.EventidEventregFk)
                    .HasConstraintName("EventId_Eventreg_FK");

                entity.HasOne(d => d.UserIdEventregFkNavigation)
                    .WithMany(p => p.Eventreg)
                    .HasForeignKey(d => d.UserIdEventregFk)
                    .HasConstraintName("UserId_Eventreg_FK");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("user");

                entity.HasIndex(e => e.UserProfileIdUserFk)
                    .HasName("UserProfileId_idx");

                entity.Property(e => e.UserId).HasColumnType("int(11)");

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.IsDeleted)
                    .HasColumnName("isDeleted")
                    .HasColumnType("bit(1)");

                entity.Property(e => e.Password).HasColumnType("varchar(128)");

                entity.Property(e => e.UserProfileIdUserFk)
                    .HasColumnName("UserProfileId_User_FK")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Username).HasColumnType("varchar(45)");

                entity.HasOne(d => d.UserProfileIdUserFkNavigation)
                    .WithMany(p => p.User)
                    .HasForeignKey(d => d.UserProfileIdUserFk)
                    .HasConstraintName("UserProfileId_User_FK");
            });

            modelBuilder.Entity<Userprofile>(entity =>
            {
                entity.ToTable("userprofile");

                entity.Property(e => e.UserProfileId).HasColumnType("int(11)");

                entity.Property(e => e.Contact).HasColumnType("int(11)");

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.Email).HasColumnType("varchar(45)");

                entity.Property(e => e.IsDeleted)
                    .HasColumnName("isDeleted")
                    .HasColumnType("bit(1)");

                entity.Property(e => e.Name).HasColumnType("varchar(45)");

                entity.Property(e => e.UpdatedDate).HasColumnType("datetime");
            });
        }
    }
}

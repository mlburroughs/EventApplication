using EventCatalogAPI.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EventCatalogAPI.Data
{
    public class EventContext : DbContext
    {
        // Dependency Injection
        public EventContext(DbContextOptions options) : base(options)
        { }

        public DbSet<EventType> EventTypes { get; set; }
        public DbSet<EventCategory> EventCategories { get; set; }
        public DbSet<EventMetroCity> EventMetroCities { get; set; }
        public DbSet<EventOrganizer> EventOrganizers { get; set; }
        public DbSet<EventItem> Events { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<EventType>(e =>
            {
                e.Property(a => a.Id)
                    .IsRequired()
                    .ValueGeneratedOnAdd();

                e.Property(a => a.Type)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<EventCategory>(e =>
            {
                e.Property(b => b.Id)
                    .IsRequired()
                    .ValueGeneratedOnAdd();

                e.Property(b => b.Category)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<EventMetroCity>(e =>
            {
                e.Property(c => c.Id)
                    .IsRequired()
                    .ValueGeneratedOnAdd();

                e.Property(c => c.MetroCity)
                    .IsRequired()
                    .HasMaxLength(40);
            });

            modelBuilder.Entity<EventOrganizer>(e =>
            {
                e.Property(d => d.Id)
                    .IsRequired()
                    .ValueGeneratedOnAdd();

                e.Property(d => d.OrganizerName)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<EventItem>(e =>
            {
                e.Property(f => f.Id)
                    .IsRequired()
                    .ValueGeneratedOnAdd();

                e.Property(f => f.Name)
                    .IsRequired()
                    .HasMaxLength(100);

                e.Property(f => f.Description)
                    .HasMaxLength(500);

                e.Property(f => f.EventDateTime)
                    .IsRequired()
                    .HasMaxLength(50);

                e.Property(f => f.Price)
                    .IsRequired()
                    .HasPrecision(10,2);

                e.Property(f => f.RefundPolicy)
                    .IsRequired()
                    .HasMaxLength(100);

                e.HasOne(f => f.EventType)
                    .WithMany()
                    .HasForeignKey(f => f.EventTypeId);

                e.HasOne(f => f.EventCategory)
                    .WithMany()
                    .HasForeignKey(f => f.EventCategoryId);

                e.HasOne(f => f.EventMetroCity)
                    .WithMany()
                    .HasForeignKey(f => f.EventMetroCityId);

                e.HasOne(f => f.EventOrganizer)
                    .WithMany()
                    .HasForeignKey(f => f.EventOrganizerId);
            });
        }
    }
}

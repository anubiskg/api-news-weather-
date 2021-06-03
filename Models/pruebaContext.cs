using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace webapi_news_weather.Models
{
    public partial class pruebaContext : DbContext
    {
        public pruebaContext()
        {
        }

        public pruebaContext(DbContextOptions<pruebaContext> options)
            : base(options)
        {
        }

        public virtual DbSet<History> Histories { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Modern_Spanish_CI_AS");

            modelBuilder.Entity<History>(entity =>
            {
                entity.ToTable("history");

                entity.Property(e => e.Id).HasColumnName("id").ValueGeneratedOnAdd();

                entity.Property(e => e.City)
                    .IsRequired()
                    .HasMaxLength(30)
                    .HasColumnName("city")
                    .IsFixedLength(true);

                entity.Property(e => e.Info)
                    .IsRequired()
                    .HasColumnType("ntext")
                    .HasColumnName("info");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}

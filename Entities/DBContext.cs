using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Library.Entities
{
    public partial class DBContext : DbContext
    {
        public DBContext()
        {
        }

        public DBContext(DbContextOptions<DBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Book> Books { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.UseCollation("utf8mb4_0900_ai_ci")
                .HasCharSet("utf8mb4");

            modelBuilder.Entity<Book>(entity =>
            {
                entity.Property(e => e.Author).HasMaxLength(255);

                entity.Property(e => e.Language).HasMaxLength(255);

                entity.Property(e => e.Published).HasColumnType("datetime");

                entity.Property(e => e.Shelf).HasMaxLength(255);

                entity.Property(e => e.Subject).HasMaxLength(45);

                entity.Property(e => e.Title).HasMaxLength(255);

                entity.Property(e => e.Version).HasMaxLength(255);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}

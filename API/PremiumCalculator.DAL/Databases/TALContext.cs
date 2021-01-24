using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using PremiumCalculator.DAL.DomainModels.PremiumCalculatorModels;

namespace PremiumCalculator.DAL.Databases
{
    public partial class TALContext : DbContext
    {
        public TALContext()
        {
        }

        public TALContext(DbContextOptions<TALContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Occupation> Occupation { get; set; }
        public virtual DbSet<OccupationRating> OccupationRating { get; set; }

        public static string ConnectionString
        {
            get; set;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(ConnectionString);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Occupation>(entity =>
            {
                entity.Property(e => e.CreatedOn)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Occupation1)
                    .IsRequired()
                    .HasColumnName("Occupation")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.Rating)
                    .WithMany(p => p.Occupation)
                    .HasForeignKey(d => d.RatingId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Occupation_OccupationRating");
            });

            modelBuilder.Entity<OccupationRating>(entity =>
            {
                entity.HasKey(e => e.RatingId);

                entity.Property(e => e.CreatedOn)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Factor).HasColumnType("decimal(18, 0)");

                entity.Property(e => e.Rating)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}

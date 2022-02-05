using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace TravelAgencyWebApi.Models
{
    public partial class finalevaluationContext : DbContext
    {
        public finalevaluationContext()
        {
        }

        public finalevaluationContext(DbContextOptions<finalevaluationContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Covering> Covering { get; set; }
        public virtual DbSet<Destination> Destination { get; set; }
        public virtual DbSet<Planperiod> Planperiod { get; set; }
        public virtual DbSet<Planprice> Planprice { get; set; }
        public virtual DbSet<Plans> Plans { get; set; }
        public virtual DbSet<Transpordmode> Transpordmode { get; set; }

//        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
//        {
//            if (!optionsBuilder.IsConfigured)
//            {
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
//                optionsBuilder.UseSqlServer("Data Source= GANESHA\\SQLEXPRESS; Initial Catalog= finalevaluation; Integrated security=True");
//            }
//        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Covering>(entity =>
            {
                entity.HasKey(e => new { e.PlaceId, e.DestinationId })
                    .HasName("PK__covering__BA7B7D73F845F8BA");

                entity.ToTable("covering");

                entity.Property(e => e.PlaceId).HasColumnName("place_id");

                entity.Property(e => e.DestinationId).HasColumnName("destination_id");

                entity.Property(e => e.PlaceName)
                    .HasColumnName("place_name")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.HasOne(d => d.Destination)
                    .WithMany(p => p.Covering)
                    .HasForeignKey(d => d.DestinationId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__covering__destin__5535A963");
            });

            modelBuilder.Entity<Destination>(entity =>
            {
                entity.ToTable("destination");

                entity.Property(e => e.DestinationId)
                    .HasColumnName("destination_id")
                    .ValueGeneratedNever();

                entity.Property(e => e.DestinationName)
                    .HasColumnName("destination_name")
                    .HasMaxLength(20)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Planperiod>(entity =>
            {
                entity.HasKey(e => new { e.PeriodId, e.PlanId })
                    .HasName("PK__Planperi__2EC843C7D4BA9BDB");

                entity.Property(e => e.PeriodId).HasColumnName("PeriodID");

                entity.Property(e => e.PlanId).HasColumnName("plan_id");

                entity.Property(e => e.Noofdays).HasColumnName("noofdays");

                entity.HasOne(d => d.Plan)
                    .WithMany(p => p.Planperiod)
                    .HasForeignKey(d => d.PlanId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Planperio__plan___5AEE82B9");
            });

            modelBuilder.Entity<Planprice>(entity =>
            {
                entity.HasKey(e => new { e.Ppid, e.PeriodId, e.Tid, e.PlanId })
                    .HasName("PK__Planpric__F8852D5185EDDE31");

                entity.Property(e => e.Ppid).HasColumnName("PPID");

                entity.Property(e => e.PeriodId).HasColumnName("PeriodID");

                entity.Property(e => e.Tid).HasColumnName("TID");

                entity.Property(e => e.PlanId).HasColumnName("plan_id");

                entity.Property(e => e.Amount).HasColumnName("amount");

                entity.HasOne(d => d.Plan)
                    .WithMany(p => p.Planprice)
                    .HasForeignKey(d => d.PlanId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Planprice__plan___60A75C0F");

                entity.HasOne(d => d.P)
                    .WithMany(p => p.Planprice)
                    .HasForeignKey(d => new { d.PeriodId, d.PlanId })
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Planprice__619B8048");

                entity.HasOne(d => d.Transpordmode)
                    .WithMany(p => p.Planprice)
                    .HasForeignKey(d => new { d.Tid, d.PlanId })
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Planprice__628FA481");
            });

            modelBuilder.Entity<Plans>(entity =>
            {
                entity.HasKey(e => e.PlanId)
                    .HasName("PK__plans__BE9F8F1D87C5F1D4");

                entity.ToTable("plans");

                entity.Property(e => e.PlanId)
                    .HasColumnName("plan_id")
                    .ValueGeneratedNever();

                entity.Property(e => e.DestinationId).HasColumnName("destination_id");

                entity.Property(e => e.PlanName)
                    .HasColumnName("plan_name")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.HasOne(d => d.Destination)
                    .WithMany(p => p.Plans)
                    .HasForeignKey(d => d.DestinationId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__plans__destinati__5812160E");
            });

            modelBuilder.Entity<Transpordmode>(entity =>
            {
                entity.HasKey(e => new { e.Tid, e.PlanId })
                    .HasName("PK__Transpor__0FBF2FD8F37179D7");

                entity.Property(e => e.Tid).HasColumnName("TID");

                entity.Property(e => e.PlanId).HasColumnName("plan_id");

                entity.Property(e => e.Tname)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.HasOne(d => d.Plan)
                    .WithMany(p => p.Transpordmode)
                    .HasForeignKey(d => d.PlanId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Transpord__plan___5DCAEF64");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}

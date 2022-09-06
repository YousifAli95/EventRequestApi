using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Models.Entities
{
    public partial class EventsContext : DbContext
    {
        public EventsContext()
        {
        }

        public EventsContext(DbContextOptions<EventsContext> options)
            : base(options)
        {
        }

        public virtual DbSet<BillOrShipInfo> BillOrShipInfos { get; set; } = null!;
        public virtual DbSet<Event> Events { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<BillOrShipInfo>(entity =>
            {
                entity.ToTable("BillOrShipInfo");

                entity.Property(e => e.Address).HasMaxLength(100);

                entity.Property(e => e.City).HasMaxLength(100);

                entity.Property(e => e.Name).HasMaxLength(100);

                entity.Property(e => e.State).HasMaxLength(100);

                entity.Property(e => e.Zip).HasMaxLength(5);
            });

            modelBuilder.Entity<Event>(entity =>
            {
                entity.Property(e => e.BillToId).HasColumnName("BillToID");

                entity.Property(e => e.Name).HasMaxLength(100);

                entity.Property(e => e.Price).HasColumnType("money");

                entity.Property(e => e.ShipToId).HasColumnName("ShipToID");

                entity.Property(e => e.Sku)
                    .HasMaxLength(100)
                    .HasColumnName("SKU");

                entity.HasOne(d => d.BillTo)
                    .WithMany(p => p.EventBillTos)
                    .HasForeignKey(d => d.BillToId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Events__BillToID__267ABA7A");

                entity.HasOne(d => d.ShipTo)
                    .WithMany(p => p.EventShipTos)
                    .HasForeignKey(d => d.ShipToId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Events__ShipToID__276EDEB3");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}

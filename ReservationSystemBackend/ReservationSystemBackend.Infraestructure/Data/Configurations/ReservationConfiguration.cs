using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ReservationSystemBackend.Core.Entities;

namespace ReservationSystemBackend.Infraestructure.Data.Configurations
{
    public class ReservationConfiguration : IEntityTypeConfiguration<Reservation>
    {
        public void Configure(EntityTypeBuilder<Reservation> builder)
        {
            builder.ToTable("Reservation");

            builder.Property(e => e.CreationDate).HasColumnType("datetime");
            builder.Property(e => e.Details).HasColumnType("text");
            builder.Property(e => e.ReservationDate).HasColumnType("datetime");

            builder.HasOne(d => d.IdClientNavigation).WithMany(p => p.Reservations)
                .HasForeignKey(d => d.IdClient)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Reservation_Client");

            builder.HasOne(d => d.IdServiceTypeNavigation).WithMany(p => p.Reservations)
                .HasForeignKey(d => d.IdServiceType)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Reservation_ServiceType");
        }
    }
}

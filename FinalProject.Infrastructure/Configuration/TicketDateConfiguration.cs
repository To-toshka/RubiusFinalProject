using FinalProject.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
namespace FinalProject.Infrastructure.Configuration
{
    /// <summary>
    /// Класс описываюший параметры таблицы TicketData в БД.
    /// </summary>
    internal class TicketDateConfiguration : IEntityTypeConfiguration<TicketData>
    {
        public void Configure(EntityTypeBuilder<TicketData> builder)
        {
            builder.HasKey(ad => ad.Id);
            builder.Property(ad => ad.Name).HasMaxLength(100);
            builder.Property(ad => ad.Surname).HasMaxLength(100);
            builder.Property(ad => ad.Patronymic).HasMaxLength(100);
            builder.Property(ad => ad.Seat).HasMaxLength(16);
            builder.Property(ad => ad.Price).HasColumnType("decimal");
            builder.Property(ad => ad.ReservationId).IsRequired().HasColumnType("bigint");;

            builder.HasOne(ad => ad.Ticket)
                .WithOne(a => a.TicketData)
                .HasForeignKey<Ticket>(a => a.Id);

            builder.HasOne(ad => ad.Reservation)
                .WithMany(a => a.TicketsDatas)
                .HasForeignKey(a => a.ReservationId);
        }
    }
}

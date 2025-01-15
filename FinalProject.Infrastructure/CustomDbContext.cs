using FinalProject.Domain;
using FinalProject.Infrastructure.Configuration;
using Microsoft.EntityFrameworkCore;

namespace FinalProject.Infrastructure
{
    /// <summary>
    /// Класс контекста базы данных.
    /// </summary>
    public class CustomDbContext : DbContext
    {
        public CustomDbContext(DbContextOptions<CustomDbContext> options) : base(options) 
        { 

        }

        /// <summary>
        /// Пользователи.
        /// </summary>
        public DbSet<User> Users { get; set; }

        /// <summary>
        /// Перевозчики.
        /// </summary>
        public DbSet<Operator> Operators { get; set; }

        /// <summary>
        /// Платежи.
        /// </summary>
        public DbSet<Payment> Payments { get; set; }

        /// <summary>
        /// Бронирования.
        /// </summary>
        public DbSet<Reservation> Reservations { get; set; }

        /// <summary>
        /// Билеты.
        /// </summary>
        public DbSet<Ticket> Tickets { get; set; }

        /// <summary>
        /// Данные пассажиров в билетах.
        /// </summary>
        public DbSet<TicketData> TicketDatas { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new TicketDateConfiguration());
        }
    }
}

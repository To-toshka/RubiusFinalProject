namespace FinalProject.Domain
{
    /// <summary>
    /// Данные пассажира в билете.
    /// </summary>
    public class TicketData : BaseEntity
    {
        /// <summary>
        /// Имя пассажира.
        /// </summary>
        public string? Name { get; set; }

        /// <summary>
        /// Фамилия пассажира.
        /// </summary>
        public string? Surname { get; set; }

        /// <summary>
        /// Отчество пассажира.
        /// </summary>
        public string? Patronymic { get; set; }

        /// <summary>
        ///Пасадочное место.
        /// </summary>
        public string? Seat { get; set; }

        /// <summary>
        /// Цена билета.
        /// </summary>
        public decimal? Price { get; set; }

        /// <summary>
        /// Идентификатор бронирования.
        /// </summary>
        public long? ReservationId { get; set; }

        /// <summary>
        /// Билет.
        /// </summary>
        public Ticket? Ticket { get; set; }

        /// <summary>
        /// Бронирование.
        /// </summary>
        public Reservation? Reservation { get; set; }
    }
}

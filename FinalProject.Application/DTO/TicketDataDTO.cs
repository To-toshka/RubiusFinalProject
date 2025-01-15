namespace FinalProject.Application.DTO
{
    /// <summary>
    /// Класс описывающий DTO Данных пассажира в билете (TicketData).
    /// </summary>
    public class TicketDataDTO : BaseDTO
    {
        /// <summary>
        /// Имя пассажира.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Фамилия пассажира.
        /// </summary>
        public string Surname { get; set; }

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
        public decimal Price { get; set; }

        /// <summary>
        /// Идентификатор бронирования.
        /// </summary>
        public long ReservationId { get; set; }
    }
}

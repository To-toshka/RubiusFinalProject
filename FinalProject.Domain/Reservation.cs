namespace FinalProject.Domain
{
    /// <summary>
    /// Бронирование.
    /// </summary>
    public class Reservation : BaseEntity
    {
        /// <summary>
        /// Номер бронирования.
        /// </summary>
        public string? ReservationNumber {  get; set; }

        /// <summary>
        /// Дата бронирования.
        /// </summary>
        public DateTime? CreatedDate { get; set; }

        /// <summary>
        /// Статус бронирования.
        /// </summary>
        public string? Status { get; set; }
        
        /// <summary>
        /// Полная стоимость бронирования.
        /// </summary>
        public decimal? TotalPrice { get; set; }

        /// <summary>
        /// Комиссия агрегатора.
        /// </summary>
        public decimal? Commission { get; set; }

        /// <summary>
        /// Идентификатор пользователя.
        /// </summary>
        public long? UserId { get; set; }

        /// <summary>
        /// Пользователь.
        /// </summary>
        public User? User { get; set; }

        /// <summary>
        /// Оплата.
        /// </summary>
        public Payment? Payment { get; set; }

        /// <summary>
        /// Билеты.
        /// </summary>
        public ICollection<TicketData>? TicketsDatas { get; set; }
    }
}

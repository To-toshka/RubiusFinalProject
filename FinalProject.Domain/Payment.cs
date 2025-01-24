namespace FinalProject.Domain
{
    /// <summary>
    /// Оплата.
    /// </summary>
    public class Payment : BaseEntity
    {
        /// <summary>
        /// Статус оплаты.
        /// </summary>
        public string? PaymentStatus { get; set; }

        /// <summary>
        /// Номер оплаты.
        /// </summary>
        public string? PaymentNumber { get; set; }

        /// <summary>
        /// Дата оплаты.
        /// </summary>
        public DateTime? PaymentDate { get; set; }

        /// <summary>
        /// Уникальный идентификатор пользователя.
        /// </summary>
        public long? UserId { get; set; }

        /// <summary>
        /// Уникальный идентификатор бронирования.
        /// </summary>
        public long? ReservationId { get; set; }

        /// <summary>
        /// Размер платежа.
        /// </summary>
        public decimal? Amount { get; set; }

        /// <summary>
        /// Банк отправителя.
        /// </summary>
        public string? SenderBank { get; set; }

        /// <summary>
        /// Счет отправителя.
        /// </summary>
        public string? SenderPaymentAccount { get; set; }

        /// <summary>
        /// Банк получателя.
        /// </summary>
        public string? RecipientBank { get; set; }

        /// <summary>
        /// Счет получателя.
        /// </summary>
        public string? RecipientPaymentAccount { get; set; }

        /// <summary>
        /// Пользователь.
        /// </summary>
        public User? User { get; set; }

        /// <summary>
        /// Бронирование.
        /// </summary>
        public Reservation? Reservation { get; set; }
    }
}

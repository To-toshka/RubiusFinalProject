namespace FinalProject.Domain
{
    /// <summary>
    /// Пользователь.
    /// </summary>
    public class User : BaseEntity
    {
        /// <summary>
        /// Логин пользователя.
        /// </summary>
        public string Login {  get; set; }

        /// <summary>
        /// Пароль пользователя.
        /// </summary>
        public string Password { get; set; }

        /// <summary>
        /// Дата рождения пользователя.
        /// </summary>
        public DateOnly? BirthDate { get; set; }

        /// <summary>
        /// Электронная почта пользователя.
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// Бронирования пользователя.
        /// </summary>
        public ICollection<Reservation>? Reservations { get; set; }

        /// <summary>
        /// Оплаты бронирований пользователя.
        /// </summary>
        public ICollection<Payment>? Payments { get; set; }
    }
}

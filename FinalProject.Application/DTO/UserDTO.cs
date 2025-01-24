namespace FinalProject.Application.DTO
{
    /// <summary>
    /// Класс описывающий DTO Пользователя (User).
    /// </summary>
    public class UserDTO : BaseDTO
    {
        /// <summary>
        /// Логин пользователя.
        /// </summary>
        public string? Login { get; set; }

        /// <summary>
        /// Пароль пользователя.
        /// </summary>
        public string? Password { get; set; }

        /// <summary>
        /// Дата рождения пользователя.
        /// </summary>
        public DateOnly? BirthDate { get; set; }

        /// <summary>
        /// Электронная почта пользователя.
        /// </summary>
        public string? Email { get; set; }
    }
}

namespace FinalProject.Application.Exceptions
{
    /// <summary>
    /// Ошибка возникающая при нарушении правила уникальности пользователя.
    /// </summary>
    public class NotUniqueException : Exception
    {
        /// <summary>
        /// Бащовый конструктор ошибки.
        /// </summary>
        public NotUniqueException() { }

        /// <summary>
        /// Констуктор ошибки принимающий сообщение для вывода.
        /// </summary>
        /// <param name="message">Сообщение для пользователя.</param>
        public NotUniqueException(string message) : base(message) { }
    }
}

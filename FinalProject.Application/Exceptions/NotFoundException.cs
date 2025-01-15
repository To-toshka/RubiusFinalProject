namespace FinalProject.Application.Exceptions
{
    /// <summary>
    /// Ошибка возникающая при отсутсвии результата поиска.
    /// </summary>
    public class NotFoundException : Exception
    {
        /// <summary>
        /// Бащовый конструктор ошибки.
        /// </summary>
        public NotFoundException() { }

        /// <summary>
        /// Констуктор ошибки принимающий сообщение для вывода.
        /// </summary>
        /// <param name="message">Сообщение для пользователя.</param>
        public NotFoundException(string message) : base(message) { }
    }
}

namespace FinalProject.Domain
{
    /// <summary>
    /// Билет.
    /// </summary>
    public class Ticket : BaseEntity
    {
        /// <summary>
        /// Класс билета.
        /// </summary>
        public string TicketClass { get; set; }

        /// <summary>
        /// Статус.
        /// </summary>
        public string Status { get; set; }

        /// <summary>
        /// Рейс.
        /// </summary>
        public string Flight { get; set; }

        /// <summary>
        /// Дата отправления.
        /// </summary>
        public DateTime DepartureDate { get; set; }

        /// <summary>
        /// Дата прибытия.
        /// </summary>
        public DateTime ArrivalDate {  get; set; }

        /// <summary>
        /// Место отправления.
        /// </summary>
        public string DeparturePlace { get; set; }

        /// <summary>
        /// Место прибытия
        /// </summary>
        public string ArrivalPlace { get; set; }

        /// <summary>
        /// Идентификатор перевозчика.
        /// </summary>
        public long OperatorId { get; set; }

        /// <summary>
        /// Перевозчик.
        /// </summary>
        public Operator Operator { get; set; }

        /// <summary>
        /// Данные пассажира.
        /// </summary>
        public TicketData? TicketData { get; set; }
    }
}

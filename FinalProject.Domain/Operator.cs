namespace FinalProject.Domain
{
    /// <summary>
    /// Перевозчик.
    /// </summary>
    public class Operator : BaseEntity
    {
        /// <summary>
        /// Название.
        /// </summary>
        public string? Name { get; set; }

        /// <summary>
        /// Описание.
        /// </summary>
        public string? Description { get; set; }

        /// <summary>
        /// Банк перевозчика.
        /// </summary>
        public string? Bank { get; set; }

        /// <summary>
        /// Расчетный счет.
        /// </summary>
        public string? PaymentAccount { get; set; }

        /// <summary>
        /// Билеты.
        /// </summary>
        public ICollection<Ticket>? Tickets { get; set; }
    }
}

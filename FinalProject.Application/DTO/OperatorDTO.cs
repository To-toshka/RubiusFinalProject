namespace FinalProject.Application.DTO
{
    /// <summary>
    /// Класс описывающий DTO Перевозчика (Operator).
    /// </summary>
    public class OperatorDTO : BaseDTO
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
    }
}

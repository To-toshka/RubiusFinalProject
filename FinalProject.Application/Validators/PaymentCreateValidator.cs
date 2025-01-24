using FinalProject.Application.DTO;
using FluentValidation;

namespace FinalProject.Application.Validators
{
    /// <summary>
    /// Клас описывающий валидацию запроса в соответсвии с бизнеслогикой.
    /// </summary>
    public class PaymentCreateValidator : AbstractValidator<PaymentDTO>
    {
        public PaymentCreateValidator()
        {
            RuleFor(request => request.Id).Null().WithMessage("'Id' не является входным параметром");
            RuleFor(request => request.PaymentNumber).NotNull().NotEmpty().WithMessage("Не указан 'Номер оплаты'");
            RuleFor(request => request.PaymentStatus).Null().WithMessage("'Статус оплаты' не является входным параметром");
            RuleFor(request => request.PaymentDate).NotNull().NotEmpty().WithMessage("Не указана 'Дата оплаты'");
            RuleFor(request => request.UserId).NotNull().NotEmpty().WithMessage("Не указан 'Id пользователя'");
            RuleFor(request => request.ReservationId).NotNull().NotEmpty().WithMessage("Не указан 'Id бронирования'");
            RuleFor(request => request.Amount).NotNull().NotEmpty().WithMessage("Не указан 'Размер платежа'");
            RuleFor(request => request.SenderBank).NotNull().NotEmpty().WithMessage("Не указан 'Банк отправителя'");
            RuleFor(request => request.RecipientBank).NotNull().NotEmpty().WithMessage("Не указан 'Банк получателя'");
            RuleFor(request => request.SenderPaymentAccount).NotNull().NotEmpty().WithMessage("Не указан 'Счет отправителя'");
            RuleFor(request => request.RecipientPaymentAccount).NotNull().NotEmpty().WithMessage("Не указан 'Счет получателя'");
        }
    }
}

using FinalProject.Application.DTO;
using FluentValidation;

namespace FinalProject.Application.Validators
{
    /// <summary>
    /// Клас описывающий валидацию запроса в соответсвии с бизнеслогикой.
    /// </summary>
    public class PaymentUpdateValidator : AbstractValidator<PaymentDTO>
    {        
        public PaymentUpdateValidator()
        {
            RuleFor(request => request.Id).NotNull().NotEmpty().WithMessage("Не указан 'Id'");
            RuleFor(request => request.PaymentNumber).Null().WithMessage("'Номер оплаты' не является входным параметром");
            RuleFor(request => request.PaymentDate).Null().WithMessage("'Дата оплаты' не является входным параметром");
            RuleFor(request => request.UserId).Null().WithMessage("'Id пользователя' не является входным параметром");
            RuleFor(request => request.ReservationId).Null().WithMessage("'Id бронирования' не является входным параметро");
            RuleFor(request => request.Amount).Null().WithMessage("'Размер платежа' не является входным параметро");
            RuleFor(request => request.SenderBank).Null().WithMessage("'Банк отправителя' не является входным параметро");
            RuleFor(request => request.RecipientBank).Null().WithMessage("'Банк получателя' не является входным параметро");
            RuleFor(request => request.SenderPaymentAccount).Null().WithMessage("'Счет отправителя' не является входным параметро");
            RuleFor(request => request.RecipientPaymentAccount).Null().WithMessage("'Счет получателя' не является входным параметро");
        }
    }
}

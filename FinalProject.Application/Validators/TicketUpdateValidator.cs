using FinalProject.Application.DTO;
using FluentValidation;

namespace FinalProject.Application.Validators
{
    /// <summary>
    /// Клас описывающий валидацию запроса в соответсвии с бизнеслогикой.
    /// </summary>
    public class TicketUpdateValidator : AbstractValidator<TicketDTO>
    {
        public TicketUpdateValidator()
        {
            RuleFor(request => request.Id).NotNull().NotEmpty().WithMessage("Не указан 'Id'");
            RuleFor(request => request.TicketNumber).Null().WithMessage("'Номер билета' не является входным параметром");
            RuleFor(request => request.OperatorId).Null().WithMessage("'Id Перевозчика'  не является входным параметром");
        }
    }
}

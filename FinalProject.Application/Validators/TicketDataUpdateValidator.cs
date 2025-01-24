using FinalProject.Application.DTO;
using FluentValidation;

namespace FinalProject.Application.Validators
{
    /// <summary>
    /// Клас описывающий валидацию запроса в соответсвии с бизнеслогикой.
    /// </summary>
    public class TicketDataUpdateValidator : AbstractValidator<TicketDataDTO>
    {
        public TicketDataUpdateValidator()
        {
            RuleFor(request => request.Id).NotNull().NotEmpty().WithMessage("Не указан 'Id'");
        }
    }
}

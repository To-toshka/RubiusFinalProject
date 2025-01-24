using FinalProject.Application.DTO;
using FluentValidation;

namespace FinalProject.Application.Validators
{
    /// <summary>
    /// Клас описывающий валидацию запроса в соответсвии с бизнеслогикой.
    /// </summary>
    public class OperatorCreateValidator : AbstractValidator<OperatorDTO>
    {
        public OperatorCreateValidator()
        {
            RuleFor(request => request.Id).Null().WithMessage("'Id' не является входным параметром");
            RuleFor(request => request.Name).NotNull().NotEmpty().WithMessage("Не указано 'Название перевозчика'");
            RuleFor(request => request.Bank).NotNull().NotEmpty().WithMessage("Не указан 'Банк перевозчика'");
            RuleFor(request => request.PaymentAccount).NotNull().NotEmpty().WithMessage("Не указан 'Рассчетный счет перевозчика'");
        }
    }
}

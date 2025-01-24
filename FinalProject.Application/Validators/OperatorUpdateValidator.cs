using FinalProject.Application.DTO;
using FluentValidation;

namespace FinalProject.Application.Validators
{
    /// <summary>
    /// Клас описывающий валидацию запроса в соответсвии с бизнеслогикой.
    /// </summary>
    public class OperatorUpdateValidator : AbstractValidator<OperatorDTO>
    {
        public OperatorUpdateValidator()
        {
            RuleFor(request => request.Id).NotNull().NotEmpty().WithMessage("Не указан 'Id'");
            RuleFor(request => request.Name).Null().WithMessage("'Название перевозчика' не является входным параметром");
        }
    }
}

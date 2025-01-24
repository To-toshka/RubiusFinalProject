using FinalProject.Application.DTO;
using FluentValidation;

namespace FinalProject.Application.Validators
{
    /// <summary>
    /// Клас описывающий валидацию запроса в соответсвии с бизнеслогикой.
    /// </summary>
    public class UserCreateValidator : AbstractValidator<UserDTO>
    {
        public UserCreateValidator()
        {
            RuleFor(request => request.Id).Null().WithMessage("'Id' не является входным параметром");
            RuleFor(request => request.Login).NotNull().NotEmpty().WithMessage("Не указан 'Логин'");
            RuleFor(request => request.Password).NotNull().NotEmpty().WithMessage("Не указан 'Пароль'");
            RuleFor(request => request.Email).NotNull().NotEmpty().WithMessage("Не указана 'Электронная почта'");
        }
    }
}

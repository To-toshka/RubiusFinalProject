using FinalProject.Application.DTO;
using FluentValidation;

namespace FinalProject.Application.Validators
{
    /// <summary>
    /// Клас описывающий валидацию запроса в соответсвии с бизнеслогикой.
    /// </summary>
    public class UserUpdateValidator : AbstractValidator<UserDTO>
    {
        public UserUpdateValidator()
        {
            RuleFor(request => request.Id).NotNull().NotEmpty().WithMessage("Не указан 'Id'");
        }
    }
}

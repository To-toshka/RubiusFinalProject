using FinalProject.Application.DTO;
using FluentValidation;

namespace FinalProject.Application.Validators
{
    /// <summary>
    /// Клас описывающий валидацию запроса в соответсвии с бизнеслогикой.
    /// </summary>
    public class ReservationUpdateValidator : AbstractValidator<ReservationDTO>
    {        
        public ReservationUpdateValidator()
        {
            RuleFor(request => request.Id).NotNull().NotEmpty().WithMessage("Не указан 'Id'");
            RuleFor(request => request.ReservationNumber).Null().WithMessage("'Номер бронирования' не является входным параметром");
            RuleFor(request => request.CreatedDate).Null().WithMessage("'Дата бронирования' не является входным параметром");
            RuleFor(request => request.UserId).Null().WithMessage("'Id пользователя' не является входным параметром");
        }
    }
}

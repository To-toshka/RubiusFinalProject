using FinalProject.Application.DTO;
using FluentValidation;

namespace FinalProject.Application.Validators
{
    /// <summary>
    /// Клас описывающий валидацию запроса в соответсвии с бизнеслогикой.
    /// </summary>
    public class ReservationCreateValidator : AbstractValidator<ReservationDTO>
    {        
        public ReservationCreateValidator()
        {
            RuleFor(request => request.Id).Null().WithMessage("'Id' не является входным параметром");
            RuleFor(request => request.ReservationNumber).NotNull().NotEmpty().WithMessage("Не указан 'Номер бронирования'");
            RuleFor(request => request.CreatedDate).Null().WithMessage("'Дата бронирования' не является входным параметром");
            RuleFor(request => request.Status).Null().WithMessage("'Статус бронирования' не является входным параметром");
            RuleFor(request => request.TotalPrice).NotNull().NotEmpty().WithMessage("Не указана 'Полная стоимость бронирования'");
            RuleFor(request => request.Commission).NotNull().NotEmpty().WithMessage("Не указана 'Комиссия агрегатора'");
            RuleFor(request => request.UserId).NotNull().NotEmpty().WithMessage("Не указано 'Id пользователя'");
        }
    }
}

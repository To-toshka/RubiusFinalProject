using FinalProject.Application.DTO;
using FluentValidation;

namespace FinalProject.Application.Validators
{
    /// <summary>
    /// Клас описывающий валидацию запроса в соответсвии с бизнеслогикой.
    /// </summary>
    public class TicketCreateValidator : AbstractValidator<TicketDTO>
    {
        public TicketCreateValidator()
        {
            RuleFor(request => request.Id).Null().WithMessage("'Id' не является входным параметром");
            RuleFor(request => request.TicketNumber).NotNull().NotEmpty().WithMessage("Не указан 'Номер билета'");
            RuleFor(request => request.TicketClass).NotNull().NotEmpty().WithMessage("Не указан 'Класс билета'");
            RuleFor(request => request.Status).NotNull().NotEmpty().WithMessage("Не указан 'Статус билета'");
            RuleFor(request => request.Flight).NotNull().NotEmpty().WithMessage("Не указан 'Рейс'");
            RuleFor(request => request.DepartureDate).NotNull().NotEmpty().WithMessage("Не указано 'Время отправления'");
            RuleFor(request => request.ArrivalDate).NotNull().NotEmpty().WithMessage("Не указано 'Время прибытия'");
            RuleFor(request => request.DeparturePlace).NotNull().NotEmpty().WithMessage("Не указан 'Аэропорт отправления'");
            RuleFor(request => request.ArrivalPlace).NotNull().NotEmpty().WithMessage("Не указан 'Аэропорт прибытия'");
            RuleFor(request => request.OperatorId).NotNull().NotEmpty().WithMessage("Не указан 'Id Перевозчика'");
        }
    }
}

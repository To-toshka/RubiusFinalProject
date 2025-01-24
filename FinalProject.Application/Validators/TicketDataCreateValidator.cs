using FinalProject.Application.DTO;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject.Application.Validators
{
    /// <summary>
    /// Клас описывающий валидацию запроса в соответсвии с бизнеслогикой.
    /// </summary>
    public class TicketDataCreateValidator : AbstractValidator<TicketDataDTO>
    {
        public TicketDataCreateValidator()
        {
            RuleFor(request => request.Id).NotNull().NotEmpty().WithMessage("Не указан 'Id'");
            RuleFor(request => request.Name).NotNull().NotEmpty().WithMessage("Не указано 'Имя пассажира'");
            RuleFor(request => request.Surname).NotNull().NotEmpty().WithMessage("Не указана 'Фамилия пассажира'");
            RuleFor(request => request.Price).NotNull().NotEmpty().WithMessage("Не указана 'Цена билета'");
            RuleFor(request => request.ReservationId).NotNull().NotEmpty().WithMessage("Не указано 'Id бронирования'");
        }
    }
}

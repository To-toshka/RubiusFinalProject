using AutoMapper;
using FinalProject.Application.Abstractions.Repositories;
using FinalProject.Application.Abstractions.Services;
using FinalProject.Application.DTO;
using FinalProject.Application.Validators;
using FinalProject.Domain;
using FluentValidation;

namespace FinalProject.Application.Services
{
    /// <summary>
    /// Сервис для работы с сущностью Билет (Ticket).
    /// </summary>
    /// <param name="ticketRepository">Экземпляр интерфейс для работы с сущностью в слое Infrastructure.</param>
    /// <param name="mapper">Экземпляр автомапера для конвертации сущностей.</param>
    public class TicketService(IEntitiesRepository<Ticket> ticketRepository, IMapper mapper) : IEntitieService<TicketDTO>
    {
        /// <summary>
        /// Создание билета (Ticket).
        /// </summary>
        /// <param name="ticket">Билет.</param>
        /// <returns>Id билета.</returns>
        public async Task<long> Create(TicketDTO ticket)
        {
            TicketCreateValidator validator = new();
            var validatorResult = await validator.ValidateAsync(ticket);
            if (!validatorResult.IsValid)
            {
                throw new ValidationException(validatorResult.Errors);
            }
            var entity = mapper.Map<Ticket>(ticket);
            await ticketRepository.IsUnique(entity);
            return await ticketRepository.Create(entity);
        }

        /// <summary>
        /// Удаление билета (Ticket).
        /// </summary>
        /// <param name="id">Уникальный идентификатор билета (Ticket).</param>
        /// <returns>Сообщение "OK".</returns>
        public Task<object> Delete(long id)
        {
            return ticketRepository.Delete(id);
        }

        /// <summary>
        /// Получение билета (Ticket) по id.
        /// </summary>
        /// <param name="id">Уникальный идентификатор билета (Ticket).</param>
        /// <returns>Билет (Ticket).</returns>
        public async Task<TicketDTO> GetById(long id)
        {
            var result = await ticketRepository.GetById(id);
            return mapper.Map<TicketDTO>(result);
        }

        /// <summary>
        /// Получение списка билетов.
        /// </summary>
        /// <returns>Коллекция билетов (Tickets)</returns>
        public async Task<IReadOnlyCollection<TicketDTO>> Get()
        {
            var result = await ticketRepository.Get();
            return mapper.Map<IReadOnlyCollection<TicketDTO>>(result);
        }

        /// <summary>
        /// Изменение билета (Ticket).
        /// </summary>
        /// <param name="ticket">Билет.</param>
        /// <returns>Сообщение "OK".</returns>
        public async Task<object> Update(TicketDTO ticket)
        {
            TicketUpdateValidator validator = new();
            var validatorResult = await validator.ValidateAsync(ticket);
            if (!validatorResult.IsValid)
            {
                throw new ValidationException(validatorResult.Errors);
            }
            var entity = mapper.Map<Ticket>(ticket);
            await ticketRepository.IsUniqueForUpdate(entity);
            return await ticketRepository.Update(entity);
        }

    }
}

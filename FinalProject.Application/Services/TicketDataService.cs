using AutoMapper;
using FinalProject.Application.Abstractions.Repositories;
using FinalProject.Application.Abstractions.Services;
using FinalProject.Application.DTO;
using FinalProject.Application.Validators;
using FinalProject.Domain;
using FluentValidation;
using System.Net.Sockets;

namespace FinalProject.Application.Services
{
    /// <summary>
    /// Сервис для работы с сущностью Данные пассажира в билете (TicketData).
    /// </summary>
    /// <param name="ticketDataRepository">Экземпляр интерфейс для работы с сущностью в слое Infrastructure.</param>
    /// <param name="mapper">Экземпляр автомапера для конвертации сущностей.</param>
    public class TicketDataService(IEntitiesRepository<TicketData> ticketDataRepository, IMapper mapper) : IEntitieService<TicketDataDTO>
    {
        /// <summary>
        /// Создание данных пассажира (TicketData).
        /// </summary>
        /// <param name="ticketData">Данных пассажира.</param>
        /// <returns>Id данных пассажира.</returns>
        public async Task<long> Create(TicketDataDTO ticketData)
        {
            TicketDataCreateValidator validator = new();
            var validatorResult = await validator.ValidateAsync(ticketData);
            if (!validatorResult.IsValid)
            {
                throw new ValidationException(validatorResult.Errors);
            }
            var entity = mapper.Map<TicketData>(ticketData);
            await ticketDataRepository.IsUnique(entity);
            return await ticketDataRepository.Create(entity);
        }

        /// <summary>
        /// Удаление данных пассажира (TicketData).
        /// </summary>
        /// <param name="id">Уникальный идентификатор данных пассажира (TicketData).</param>
        /// <returns>Сообщение "OK".</returns>
        public Task<object> Delete(long id)
        {
            return ticketDataRepository.Delete(id);
        }

        /// <summary>
        /// Получение данных пассажира (TicketData) по id.
        /// </summary>
        /// <param name="id">Уникальный идентификатор данных пассажира (TicketData).</param>
        /// <returns>Данные пассажира (TicketData).</returns>
        public async Task<TicketDataDTO> GetById(long id)
        {
            var result = await ticketDataRepository.GetById(id);
            return mapper.Map<TicketDataDTO>(result);
        }

        /// <summary>
        /// Получение списка данных пассажиров.
        /// </summary>
        /// <returns>Коллекция данных пассажиров (TicketData)</returns>
        public async Task<IReadOnlyCollection<TicketDataDTO>> Get()
        {
            var result = await ticketDataRepository.Get();
            return mapper.Map<IReadOnlyCollection<TicketDataDTO>>(result);
        }

        /// <summary>
        /// Изменение данных пассажира (TicketData).
        /// </summary>
        /// <param name="ticketData">Данные пассажира.</param>
        /// <returns>Сообщение "OK".</returns>
        public async Task<object> Update(TicketDataDTO ticketData)
        {
            TicketDataUpdateValidator validator = new();
            var validatorResult = await validator.ValidateAsync(ticketData);
            if (!validatorResult.IsValid)
            {
                throw new ValidationException(validatorResult.Errors);
            }
            var entity = mapper.Map<TicketData>(ticketData);
            await ticketDataRepository.IsUniqueForUpdate(entity);
            return await ticketDataRepository.Update(entity);
        }
    }
}

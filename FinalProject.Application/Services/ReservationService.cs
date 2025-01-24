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
    /// Сервис для работы с сущностью Бронирование (Reservation).
    /// </summary>
    /// <param name="reservationRepository">Экземпляр интерфейс для работы с сущностью в слое Infrastructure.</param>
    /// <param name="mapper">Экземпляр автомапера для конвертации сущностей.</param>
    public class ReservationService(IEntitiesRepository<Reservation> reservationRepository, IMapper mapper) : IEntitieService<ReservationDTO>
    {
        /// <summary>
        /// Создание бронирования (Reservation).
        /// </summary>
        /// <param name="reservation">Бронирование.</param>
        /// <returns>Id бронирования.</returns>
        public async Task<long> Create(ReservationDTO reservation)
        {
            ReservationCreateValidator validator = new();
            var validatorResult = await validator.ValidateAsync(reservation);
            if (!validatorResult.IsValid)
            {
                throw new ValidationException(validatorResult.Errors);
            }
            reservation.CreatedDate = DateTime.UtcNow;
            reservation.Status = "Ожидает оплаты";
            var entity = mapper.Map<Reservation>(reservation);
            await reservationRepository.IsUnique(entity);
            return await reservationRepository.Create(entity);
        }

        /// <summary>
        /// Удаление бронирования (Reservation).
        /// </summary>
        /// <param name="id">Уникальный идентификатор бронирования (Reservation).</param>
        /// <returns>Сообщение "OK".</returns>
        public Task<object> Delete(long id)
        {
            return reservationRepository.Delete(id);
        }

        /// <summary>
        /// Получение бронирования (Reservation) по id.
        /// </summary>
        /// <param name="id">Уникальный идентификатор бронирования (Reservation).</param>
        /// <returns>Бронирования (Reservation).</returns>
        public async Task<ReservationDTO> GetById(long id)
        {
            var result = await reservationRepository.GetById(id);
            return mapper.Map<ReservationDTO>(result);
        }

        /// <summary>
        /// Получение списка бронирований.
        /// </summary>
        /// <returns>Коллекция бронирований (Reservation)</returns>
        public async Task<IReadOnlyCollection<ReservationDTO>> Get()
        {
            var result = await reservationRepository.Get();
            return mapper.Map<IReadOnlyCollection<ReservationDTO>>(result);
        }

        /// <summary>
        /// Изменение бронирования (Reservation).
        /// </summary>
        /// <param name="reservation">Бронирование.</param>
        /// <returns>Сообщение "OK".</returns>
        public async Task<object> Update(ReservationDTO reservation)
        {
            ReservationUpdateValidator validator = new();
            var validatorResult = await validator.ValidateAsync(reservation);
            if (!validatorResult.IsValid)
            {
                throw new ValidationException(validatorResult.Errors);
            }
            var entity = mapper.Map<Reservation>(reservation);
            await reservationRepository.IsUniqueForUpdate(entity);
            return await reservationRepository.Update(entity);
        }
    }
}

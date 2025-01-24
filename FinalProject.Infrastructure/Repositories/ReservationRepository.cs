using FinalProject.Application.Abstractions.Repositories;
using FinalProject.Application.Exceptions;
using FinalProject.Domain;
using Microsoft.EntityFrameworkCore;
using System.Net.Sockets;

namespace FinalProject.Infrastructure.Repositories
{
    /// <summary>
    /// Класс реализующий работу с сущностью Бронирование (Reservation) в БД.
    /// </summary>
    /// <param name="dbContext">Экземпляр класса CustomDbContext.</param>
    public class ReservationRepository(CustomDbContext dbContext) : IEntitiesRepository<Reservation>
    {
        /// <summary>
        /// Создание новой сущности Бронирование (Reservation) в БД.
        /// </summary>
        /// <param name="reservation">Сущность Бронирование (Reservation).</param>
        /// <returns>Id сущности.</returns>
        public async Task<long> Create(Reservation reservation)
        {
            dbContext.Reservations.Add(reservation);
            await dbContext.SaveChangesAsync();
            return reservation.Id;
        }

        /// <summary>
        /// Удаление сущности Бронирование (Reservation) из БД.
        /// </summary>
        /// <param name="id">Уникальный идентификатор сущности.</param>
        /// <returns>Сообщение "OK" или сообщение об ошибке.</returns>
        /// <exception cref="NotFoundException">Ошибка возникающая при отсутсвии сущности с указанным id в БД.</exception>
        public async Task<object> Delete(long id)
        {
            int deletedRows = await dbContext.Reservations.Where(x => x.Id == id).ExecuteDeleteAsync();
            if (deletedRows > 0)
            {
                return new { Message = "OK" };
            }
            else
            {
                throw new NotFoundException($"Бронирование с идентификатором {id} не найдено.");
            }
        }

        /// <summary>
        /// Получение сущности Бронирование (Reservation) из БД по id.
        /// </summary>
        /// <param name="id">Уникальный идентификатор сущности.</param>
        /// <returns>Сущности бронирование (Reservation).</returns>
        /// <exception cref="NotFoundException">Ошибка возникающая при отсутсвии сущности с указанным id в БД.</exception>
        public async Task<Reservation> GetById(long id)
        {
            return await dbContext.Reservations.FirstOrDefaultAsync(x => x.Id == id)
                ?? throw new NotFoundException($"Бронирование с идентификатором {id} не найдено.");
        }

        /// <summary>
        /// Получение списка всех сущностей Бронирование (Reservation) хранящихся в БД.
        /// </summary>
        /// <returns>Коллекция сущностей.</returns>
        public async Task<IReadOnlyCollection<Reservation>> Get()
        {
            var result = await dbContext.Reservations.ToListAsync();
            return result;
        }

        /// <summary>
        /// Изменение сущности Бронирование (Reservation) хранящейся в БД.
        /// </summary>
        /// <param name="reservation">Новые данные для сущности Бронирование (Reservation).</param>
        /// <returns>Сообщение "OK" или сообщение об ошибке.</returns>
        /// <exception cref="NotFoundException">Ошибка возникающая при отсутсвии сущности с указанным id в БД.</exception>
        public async Task<object> Update(Reservation reservation)
        {
            var reservationForUpdate = await dbContext.Reservations.FirstOrDefaultAsync(x => x.Id == reservation.Id)
                ?? throw new NotFoundException($"Бронирование с идентификатором {reservation.Id} не найдено.");


            if (reservation.ReservationNumber != null && reservationForUpdate.ReservationNumber != reservation.ReservationNumber) reservationForUpdate.ReservationNumber = reservation.ReservationNumber;
            if (!string.IsNullOrWhiteSpace(reservation.Status) && reservationForUpdate.Status != reservation.Status) reservationForUpdate.Status = reservation.Status;
            if (reservation.TotalPrice != null && reservationForUpdate.TotalPrice != reservation.TotalPrice) reservationForUpdate.TotalPrice = reservation.TotalPrice;
            if (reservation.Commission != null && reservationForUpdate.Commission != reservation.Commission) reservationForUpdate.Commission = reservation.Commission;
            if (reservation.UserId != null && reservationForUpdate.UserId != reservation.UserId) reservationForUpdate.UserId = reservation.UserId;

            await dbContext.SaveChangesAsync();
            return new { Message = "OK" };
        }

        /// <summary>
        /// Функция проверки сущности Бронирование (Reservation) на уникальность при создании.
        /// </summary>
        /// <param name="reservation">Бронирование.</param>
        /// <returns>true или сообщение об ошибке.</returns>
        public async Task<bool> IsUnique(Reservation reservation)
        {
            if (await dbContext.Reservations.AsNoTracking().AnyAsync(x => x.ReservationNumber == reservation.ReservationNumber)) 
                throw new NotUniqueException($"Бронирование с номером {reservation.ReservationNumber} уже зарегистрировано в системе.");
            return true;
        }

        /// <summary>
        /// Функция проверки сущности Бронирование (Reservation) на уникальность при изменении.
        /// </summary>
        /// <param name="reservation">Бронирование.</param>
        /// <returns>true или сообщение об ошибке.</returns>
        public async Task<bool> IsUniqueForUpdate(Reservation reservation)
        {
            if (!string.IsNullOrWhiteSpace(reservation.ReservationNumber)
                && await dbContext.Reservations.AsNoTracking().AnyAsync(x => x.ReservationNumber == reservation.ReservationNumber && x.Id != reservation.Id)) 
                    throw new NotUniqueException($"Бронирование с номером {reservation.ReservationNumber} уже зарегистрировано в системе.");
            return true;
        }
    }
}

using FinalProject.Application.Abstractions.Repositories;
using FinalProject.Application.Exceptions;
using FinalProject.Domain;
using Microsoft.EntityFrameworkCore;
using System.Net.Sockets;

namespace FinalProject.Infrastructure.Repositories
{
    /// <summary>
    /// Класс реализующий работу с сущностью Данные пассажира (TicketData) в БД.
    /// </summary>
    /// <param name="dbContext">Экземпляр класса CustomDbContext.</param>
    public class TicketDataRepository(CustomDbContext dbContext) : IEntitiesRepository<TicketData>
    {
        /// <summary>
        /// Создание новой сущности Данные пассажира (TicketData) в БД.
        /// </summary>
        /// <param name="ticketData">Сущность Данные пассажира (TicketData).</param>
        /// <returns>Id сущности.</returns>
        public async Task<long> Create(TicketData ticketData)
        {
            dbContext.TicketDatas.Add(ticketData);
            await dbContext.SaveChangesAsync();
            return ticketData.Id;
        }

        /// <summary>
        /// Удаление сущности Данные пассажира (TicketData) из БД.
        /// </summary>
        /// <param name="id">Уникальный идентификатор сущности.</param>
        /// <returns>Сообщение "OK" или сообщение об ошибке.</returns>
        /// <exception cref="NotFoundException">Ошибка возникающая при отсутсвии сущности с указанным id в БД.</exception>
        public async Task<object> Delete(long id)
        {
            int deletedRows = await dbContext.TicketDatas.Where(x => x.Id == id).ExecuteDeleteAsync();
            if (deletedRows > 0)
            {
                return new { Message = "OK" };
            }
            else
            {
                throw new NotFoundException($"Данные пассажира с идентификатором {id} не найдены.");
            }
        }

        /// <summary>
        /// Получение сущности Данные пассажира (TicketData) из БД по id.
        /// </summary>
        /// <param name="id">Уникальный идентификатор сущности.</param>
        /// <returns>Сущности данные пассажира (TicketData).</returns>
        /// <exception cref="NotFoundException">Ошибка возникающая при отсутсвии сущности с указанным id в БД.</exception>
        public async Task<TicketData> GetById(long id)
        {
            return await dbContext.TicketDatas.FirstOrDefaultAsync(x => x.Id == id)
                ?? throw new NotFoundException($"Данные пассажира с идентификатором {id} не найдены.");
        }

        /// <summary>
        /// Получение списка всех сущностей Данные пассажира (TicketData) хранящихся в БД.
        /// </summary>
        /// <returns>Коллекция сущностей.</returns>
        public async Task<IReadOnlyCollection<TicketData>> Get()
        {
            var result = await dbContext.TicketDatas.ToListAsync();
            return result;
        }

        /// <summary>
        /// Изменение сущности Данные пассажира (TicketData) хранящейся в БД.
        /// </summary>
        /// <param name="ticketData">Новые данные для сущности Данные пассажира (TicketData).</param>
        /// <returns>Сообщение "OK" или сообщение об ошибке.</returns>
        /// <exception cref="NotFoundException">Ошибка возникающая при отсутсвии сущности с указанным id в БД.</exception>
        public async Task<object> Update(TicketData ticketData)
        {
            var ticketDataForUpdate = await dbContext.TicketDatas.FirstOrDefaultAsync(x => x.Id == ticketData.Id)
                ?? throw new NotFoundException($"Данные пассажира с идентификатором {ticketData.Id} не найдены.");

            if (!string.IsNullOrWhiteSpace(ticketData.Name) && ticketDataForUpdate.Name != ticketData.Name) ticketDataForUpdate.Name = ticketData.Name;
            if (!string.IsNullOrWhiteSpace(ticketData.Surname) && ticketDataForUpdate.Surname != ticketData.Surname) ticketDataForUpdate.Surname = ticketData.Surname;
            if (!string.IsNullOrWhiteSpace(ticketData.Patronymic) && ticketDataForUpdate.Patronymic != ticketData.Patronymic) ticketDataForUpdate.Patronymic = ticketData.Patronymic;
            if (!string.IsNullOrWhiteSpace(ticketData.Seat) && ticketDataForUpdate.Seat != ticketData.Seat) ticketDataForUpdate.Seat = ticketData.Seat;
            if (ticketData.Price != null && ticketDataForUpdate.Price != ticketData.Price) ticketDataForUpdate.Price = ticketData.Price;
            if (ticketData.ReservationId != null && ticketDataForUpdate.ReservationId != ticketData.ReservationId) ticketDataForUpdate.ReservationId = ticketData.ReservationId;

            await dbContext.SaveChangesAsync();
            return new { Message = "OK" };
        }

        /// <summary>
        /// Функция проверки сущности Данные пассажира (TicketData) на уникальность при создании.
        /// </summary>
        /// <param name="ticketData">Данные пассажира.</param>
        /// <returns>true или сообщение об ошибке.</returns>
        public async Task<bool> IsUnique(TicketData ticketData)
        {
            if (!string.IsNullOrWhiteSpace(ticketData.Seat))
            {
                var ticket = await dbContext.Tickets.AsNoTracking().FirstOrDefaultAsync(x => x.Id == ticketData.Id)
                ?? throw new NotFoundException($"Билет с идентификатором {ticketData.Id} не найдены.");

                if (await dbContext.Tickets.Where(x => x.OperatorId == ticket.OperatorId && x.Flight == ticket.Flight && x.DepartureDate == ticket.DepartureDate && x.DeparturePlace == ticket.DeparturePlace)
                        .AnyAsync(x => x.TicketData.Seat == ticketData.Seat))
                    throw new NotUniqueException($"Место {ticketData.Seat} уже зарегистрировано.");
            }            
            return true;
        }

        /// <summary>
        /// Функция проверки сущности Данные пассажира (TicketData) на уникальность при изменении.
        /// </summary>
        /// <param name="ticketData">Данные пассажира.</param>
        /// <returns>true или сообщение об ошибке.</returns>
        public async Task<bool> IsUniqueForUpdate(TicketData ticketData)
        {
            if (!string.IsNullOrWhiteSpace(ticketData.Seat))
            {
                var ticket = await dbContext.Tickets.AsNoTracking().FirstOrDefaultAsync(x => x.Id == ticketData.Id)
                ?? throw new NotFoundException($"Билет с идентификатором {ticketData.Id} не найдены.");

                if (await dbContext.Tickets.Where(x => x.OperatorId == ticket.OperatorId && x.Flight == ticket.Flight && x.DepartureDate == ticket.DepartureDate && x.DeparturePlace == ticket.DeparturePlace)
                        .AnyAsync(x => x.TicketData.Seat == ticketData.Seat && x.Id != ticketData.Id))
                    throw new NotUniqueException($"Место {ticketData.Seat} уже зарегистрировано.");
            }
            return true;
        }
    }
}

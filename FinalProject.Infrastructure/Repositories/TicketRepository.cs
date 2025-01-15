using FinalProject.Application.Abstractions.Repositories;
using FinalProject.Application.Exceptions;
using FinalProject.Domain;
using Microsoft.EntityFrameworkCore;

namespace FinalProject.Infrastructure.Repositories
{
    /// <summary>
    /// Класс реализующий работу с сущностью Билет (Ticket) в БД.
    /// </summary>
    /// <param name="dbContext">Экземпляр класса CustomDbContext.</param>
    public class TicketRepository(CustomDbContext dbContext) : IEntitiesRepository<Ticket>
    {
        /// <summary>
        /// Создание новой сущности Билет (Ticket) в БД.
        /// </summary>
        /// <param name="ticket">Сущность Билет (Ticket).</param>
        /// <returns>Id сущности.</returns>
        public async Task<long> Create(Ticket ticket)
        {
            dbContext.Tickets.Add(ticket);
            await dbContext.SaveChangesAsync();
            return ticket.Id;
        }

        /// <summary>
        /// Удаление сущности Билет (Ticket) из БД.
        /// </summary>
        /// <param name="id">Уникальный идентификатор сущности.</param>
        /// <returns>Сообщение "OK" или сообщение об ошибке.</returns>
        /// <exception cref="NotFoundException">Ошибка возникающая при отсутсвии сущности с указанным id в БД.</exception>
        public async Task<object> Delete(long id)
        {
            int deletedRows = await dbContext.Tickets.Where(x => x.Id == id).ExecuteDeleteAsync();
            if (deletedRows > 0)
            {
                return new { Message = "OK" };
            }
            else
            {
                throw new NotFoundException($"Билет с идентификатором {id} не найден.");
            }
        }

        /// <summary>
        /// Получение сущности Билет (Ticket) из БД по id.
        /// </summary>
        /// <param name="id">Уникальный идентификатор сущности.</param>
        /// <returns>Сущности билет (Ticket).</returns>
        /// <exception cref="NotFoundException">Ошибка возникающая при отсутсвии сущности с указанным id в БД.</exception>
        public async Task<Ticket> GetById(long id)
        {
            return await dbContext.Tickets.FirstOrDefaultAsync(x => x.Id == id)
                ?? throw new NotFoundException($"Билет с идентификатором {id} не найден.");
        }

        /// <summary>
        /// Получение списка всех сущностей Билет (Ticket) хранящихся в БД.
        /// </summary>
        /// <returns>Коллекция сущностей.</returns>
        public async Task<IReadOnlyCollection<Ticket>> Get()
        {
            var result = await dbContext.Tickets.ToListAsync();
            return result;
        }

        /// <summary>
        /// Изменение сущности Билет (Ticket) хранящейся в БД.
        /// </summary>
        /// <param name="ticket">Новые данные для сущности Билет (Ticket).</param>
        /// <returns>Сообщение "OK" или сообщение об ошибке.</returns>
        /// <exception cref="NotFoundException">Ошибка возникающая при отсутсвии сущности с указанным id в БД.</exception>
        public async Task<object> Update(Ticket ticket)
        {
            var ticketForUpdate = await dbContext.Tickets.FirstOrDefaultAsync(x => x.Id == ticket.Id)
                ?? throw new NotFoundException($"Билет с идентификатором {ticket.Id} не найден.");

            if (!string.IsNullOrWhiteSpace(ticket.TicketClass) && ticketForUpdate.TicketClass != ticket.TicketClass) ticketForUpdate.TicketClass = ticket.TicketClass;
            if (!string.IsNullOrWhiteSpace(ticket.Status) && ticketForUpdate.Status != ticket.Status) ticketForUpdate.Status = ticket.Status;
            if (!string.IsNullOrWhiteSpace(ticket.Flight) && ticketForUpdate.Flight != ticket.Flight) ticketForUpdate.Flight = ticket.Flight;
            if (ticket.DepartureDate != null && ticketForUpdate.DepartureDate != ticket.DepartureDate) ticketForUpdate.DepartureDate = ticket.DepartureDate;
            if (ticket.ArrivalDate != null && ticketForUpdate.ArrivalDate != ticket.ArrivalDate) ticketForUpdate.ArrivalDate = ticket.ArrivalDate;
            if (!string.IsNullOrWhiteSpace(ticket.DeparturePlace) && ticketForUpdate.DeparturePlace != ticket.DeparturePlace) ticketForUpdate.DeparturePlace = ticket.DeparturePlace;
            if (!string.IsNullOrWhiteSpace(ticket.ArrivalPlace) && ticketForUpdate.ArrivalPlace != ticket.ArrivalPlace) ticketForUpdate.ArrivalPlace = ticket.ArrivalPlace;
            if (ticket.OperatorId != null && ticketForUpdate.OperatorId != ticket.OperatorId) ticketForUpdate.OperatorId = ticket.OperatorId;

            await dbContext.SaveChangesAsync();
            return new { Message = "OK" };
        }
    }
}

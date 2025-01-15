using FinalProject.Application.Abstractions.Services;
using FinalProject.Application.DTO;
using FinalProject.Application.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FinalProject.Api.Controllers
{
    /// <summary>
    /// Контроллер Билетов (Ticket).
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class TicketsController(IEntitieService<TicketDTO> ticketService) : ControllerBase
    {
        /// <summary>
        /// Возвращает список Билетов.
        /// </summary>
        /// <returns>Коллекция билетов (Tickets).</returns>
        [HttpGet]
        public Task<IReadOnlyCollection<TicketDTO>> Get()
        {
            return ticketService.Get();
        }

        /// <summary>
        /// Возвращает Билет по Id.
        /// </summary>
        /// <param name="id">Id билета.</param>
        /// <returns>Билет.</returns>
        [HttpGet("{id}/Info")]
        public Task<TicketDTO> GetUserById(long id)
        {
            return ticketService.GetById(id);
        }

        /// <summary>
        /// Cоздает Билет.
        /// </summary>
        /// <param name="ticket">Билет.</param>
        /// <returns>Id билета.</returns>
        [HttpPost("Create")]
        public Task<long> Create(TicketDTO ticket)
        {
            return ticketService.Create(ticket);
        }

        /// <summary>
        /// Обновляет Билет.
        /// </summary>
        /// <param name="ticket">Билет.</param>
        /// <returns>Сообщение "OK".</returns>
        [HttpPost("Update")]
        public Task<object> Update(TicketDTO ticket)
        {
            return ticketService.Update(ticket);
        }

        /// <summary>
        /// Удаляе Билет.
        /// </summary>
        /// <param name="id">Id билета.</param>
        /// <returns>Сообщение "OK".</returns>
        [HttpPost("Delete")]
        public Task<object> Delete(long id)
        {
            return ticketService.Delete(id);
        }
    }
}

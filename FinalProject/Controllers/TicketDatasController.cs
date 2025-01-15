using FinalProject.Application.Abstractions.Services;
using FinalProject.Application.DTO;
using FinalProject.Application.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FinalProject.Api.Controllers
{
    /// <summary>
    /// Контроллер Данных пассажира в билете.
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class TicketDatasController(IEntitieService<TicketDataDTO> ticketDataService) : ControllerBase
    {
        /// <summary>
        /// Возвращает список Данных пассажиров.
        /// </summary>
        /// <returns>Коллекция данных пассажиров (TicketData).</returns>
        [HttpGet]
        public Task<IReadOnlyCollection<TicketDataDTO>> Get()
        {
            return ticketDataService.Get();
        }

        /// <summary>
        /// Возвращает Данные пассажира по Id.
        /// </summary>
        /// <param name="id">Id данных пассажира.</param>
        /// <returns>Данные пассажира.</returns>
        [HttpGet("{id}/Info")]
        public Task<TicketDataDTO> GetUserById(long id)
        {
            return ticketDataService.GetById(id);
        }

        /// <summary>
        /// Cоздает Данные пассажира.
        /// </summary>
        /// <param name="ticketData">Данные пассажира.</param>
        /// <returns>Id данных пассажира.</returns>
        [HttpPost("Create")]
        public Task<long> Create(TicketDataDTO ticketData)
        {
            return ticketDataService.Create(ticketData);
        }

        /// <summary>
        /// Обновляет Данные пассажира.
        /// </summary>
        /// <param name="ticketData">Данные пассажира.</param>
        /// <returns>Сообщение "OK".</returns>
        [HttpPost("Update")]
        public Task<object> Update(TicketDataDTO ticketData)
        {
            return ticketDataService.Update(ticketData);
        }

        /// <summary>
        /// Удаляе Данные пассажира.
        /// </summary>
        /// <param name="id">Id данных пассажира.</param>
        /// <returns>Сообщение "OK".</returns>
        [HttpPost("Delete")]
        public Task<object> Delete(long id)
        {
            return ticketDataService.Delete(id);
        }
    }
}

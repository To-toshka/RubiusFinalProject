using FinalProject.Application.Abstractions.Services;
using FinalProject.Application.DTO;
using FinalProject.Application.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FinalProject.Api.Controllers
{
    /// <summary>
    /// Контроллер Бронирований.
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class ReservationsController(IEntitieService<ReservationDTO> reservationService) : ControllerBase
    {
        /// <summary>
        /// Возвращает список Бронирований.
        /// </summary>
        /// <returns>Коллекция бронирований (Reservations).</returns>
        [HttpGet]
        public Task<IReadOnlyCollection<ReservationDTO>> Get()
        {
            return reservationService.Get();
        }

        /// <summary>
        /// Возвращает Бронирование по Id.
        /// </summary>
        /// <param name="id">Id бронирования.</param>
        /// <returns>Бронирование.</returns>
        [HttpGet("{id}/Info")]
        public Task<ReservationDTO> GetUserById(long id)
        {
            return reservationService.GetById(id);
        }

        /// <summary>
        /// Cоздает Бронирование.
        /// </summary>
        /// <param name="reservation">Бронирование.</param>
        /// <returns>Id бронирования.</returns>
        [HttpPost("Create")]
        public Task<long> Create(ReservationDTO reservation)
        {
            return reservationService.Create(reservation);
        }

        /// <summary>
        /// Обновляет Бронирование.
        /// </summary>
        /// <param name="reservation">Бронирование.</param>
        /// <returns>Сообщение "OK".</returns>
        [HttpPost("Update")]
        public Task<object> Update(ReservationDTO reservation)
        {
            return reservationService.Update(reservation);
        }

        /// <summary>
        /// Удаляе Бронирование.
        /// </summary>
        /// <param name="id">Id бронирования.</param>
        /// <returns>Сообщение "OK".</returns>
        [HttpPost("Delete")]
        public Task<object> Delete(long id)
        {
            return reservationService.Delete(id);
        }
    }
}

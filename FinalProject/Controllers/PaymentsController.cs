using FinalProject.Application.Abstractions.Services;
using FinalProject.Application.DTO;
using FinalProject.Application.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FinalProject.Api.Controllers
{
    /// <summary>
    /// Контроллер Оплат.
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentsController(IEntitieService<PaymentDTO> paymentService) : ControllerBase
    {
        /// <summary>
        /// Возвращает список Оплат.
        /// </summary>
        /// <returns>Коллекция оплат (Payments).</returns>
        [HttpGet]
        public Task<IReadOnlyCollection<PaymentDTO>> Get()
        {
            return paymentService.Get();
        }

        /// <summary>
        /// Возвращает Оплату по Id.
        /// </summary>
        /// <param name="id">Id оплаты.</param>
        /// <returns>Оплата.</returns>
        [HttpGet("{id}/Info")]
        public Task<PaymentDTO> GetUserById(long id)
        {
            return paymentService.GetById(id);
        }

        /// <summary>
        /// Cоздает Оплату.
        /// </summary>
        /// <param name="payment">Оплата.</param>
        /// <returns>Id оплаты.</returns>
        [HttpPost("Create")]
        public Task<long> Create(PaymentDTO payment)
        {
            return paymentService.Create(payment);
        }

        /// <summary>
        /// Обновляет Оплату.
        /// </summary>
        /// <param name="payment">Оплата.</param>
        /// <returns>Сообщение "OK".</returns>
        [HttpPost("Update")]
        public Task<object> Update(PaymentDTO payment)
        {
            return paymentService.Update(payment);
        }

        /// <summary>
        /// Удаляе Оплату.
        /// </summary>
        /// <param name="id">Id оплаты.</param>
        /// <returns>Сообщение "OK".</returns>
        [HttpPost("Delete")]
        public Task<object> Delete(long id)
        {
            return paymentService.Delete(id);
        }
    }
}

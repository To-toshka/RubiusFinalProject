using AutoMapper;
using FinalProject.Application.Abstractions.Repositories;
using FinalProject.Application.Abstractions.Services;
using FinalProject.Application.DTO;
using FinalProject.Domain;

namespace FinalProject.Application.Services
{
    /// <summary>
    /// Сервис для работы с сущностью Оплата (Payment).
    /// </summary>
    /// <param name="paymentRepository">Экземпляр интерфейс для работы с сущностью в слое Infrastructure.</param>
    /// <param name="mapper">Экземпляр автомапера для конвертации сущностей.</param>
    public class PaymentService(IEntitiesRepository<Payment> paymentRepository, IMapper mapper) : IEntitieService<PaymentDTO>
    {
        /// <summary>
        /// Получение списка оплат.
        /// </summary>
        /// <returns>Коллекция оплат (Payment)</returns>
        public async Task<IReadOnlyCollection<PaymentDTO>> Get()
        {

            var result = await paymentRepository.Get();
            return mapper.Map<IReadOnlyCollection<PaymentDTO>>(result);
        }

        /// <summary>
        /// Получение оплат (Payment) по id.
        /// </summary>
        /// <param name="id">Уникальный идентификатор оплаты (Payment).</param>
        /// <returns>Оплата (Payment).</returns>
        public async Task<PaymentDTO> GetById(long id)
        {
            var result = await paymentRepository.GetById(id);
            return mapper.Map<PaymentDTO>(result);
        }

        /// <summary>
        /// Создание оплаты (Payment).
        /// </summary>
        /// <param name="payment">Оплата.</param>
        /// <returns>Id оплаты.</returns>
        public Task<long> Create(PaymentDTO payment)
        {
            var entity = mapper.Map<Payment>(payment);
            return paymentRepository.Create(entity);
        }

        /// <summary>
        /// Изменение оплаты (Payment).
        /// </summary>
        /// <param name="payment">Оплата.</param>
        /// <returns>Сообщение "OK".</returns>
        public Task<object> Update(PaymentDTO payment)
        {
            var entity = mapper.Map<Payment>(payment);
            return paymentRepository.Update(entity);
        }

        /// <summary>
        /// Удаление оплаты (Payment).
        /// </summary>
        /// <param name="id">Уникальный идентификатор оплаты (Payment).</param>
        /// <returns>Строка "OK".</returns>
        public Task<object> Delete(long id)
        {
            return paymentRepository.Delete(id);
        }
    }
}

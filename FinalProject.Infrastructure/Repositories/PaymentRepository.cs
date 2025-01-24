using FinalProject.Application.Abstractions.Repositories;
using FinalProject.Application.Exceptions;
using FinalProject.Domain;
using Microsoft.EntityFrameworkCore;

namespace FinalProject.Infrastructure.Repositories
{
    /// <summary>
    /// Класс реализующий работу с сущностью Оплата (Payment) в БД.
    /// </summary>
    /// <param name="dbContext">Экземпляр класса CustomDbContext.</param>
    public class PaymentRepository(CustomDbContext dbContext) : IEntitiesRepository<Payment>
    {
        /// <summary>
        /// Создание новой сущности Оплата (Payment) в БД.
        /// </summary>
        /// <param name="payment">Сущность Оплата (Payment).</param>
        /// <returns>Id сущности.</returns>
        public async Task<long> Create(Payment payment)
        {
            dbContext.Payments.Add(payment);
            await dbContext.SaveChangesAsync();
            return payment.Id;
        }

        /// <summary>
        /// Удаление сущности Оплата (Payment) из БД.
        /// </summary>
        /// <param name="id">Уникальный идентификатор сущности.</param>
        /// <returns>Сообщение "OK" или сообщение об ошибке.</returns>
        /// <exception cref="NotFoundException">Ошибка возникающая при отсутсвии сущности с указанным id в БД.</exception>
        public async Task<object> Delete(long id)
        {
            int deletedRows = await dbContext.Payments.Where(x => x.Id == id).ExecuteDeleteAsync();
            if (deletedRows > 0)
            {
                return new { Message = "OK" };
            }
            else
            {
                throw new NotFoundException($"Оплата с идентификатором {id} не найдена.");
            }
        }

        /// <summary>
        /// Получение сущности Оплата (Payment) из БД по id.
        /// </summary>
        /// <param name="id">Уникальный идентификатор сущности.</param>
        /// <returns>Сущности оплата (Payment).</returns>
        /// <exception cref="NotFoundException">Ошибка возникающая при отсутсвии сущности с указанным id в БД.</exception>
        public async Task<Payment> GetById(long id)
        {
            return await dbContext.Payments.FirstOrDefaultAsync(x => x.Id == id)
                ?? throw new NotFoundException($"Оплата с идентификатором {id} не найдена.");
        }

        /// <summary>
        /// Получение списка всех сущностей Оплата (Payment) хранящихся в БД.
        /// </summary>
        /// <returns>Коллекция сущностей.</returns>
        public async Task<IReadOnlyCollection<Payment>> Get()
        {
            var result = await dbContext.Payments.ToListAsync();
            return result;
        }

        /// <summary>
        /// Изменение сущности Оплата (Payment) хранящейся в БД.
        /// </summary>
        /// <param name="payment">Новые данные для сущности Оплата (Payment).</param>
        /// <returns>Сообщение "OK" или сообщение об ошибке.</returns>
        /// <exception cref="NotFoundException">Ошибка возникающая при отсутсвии сущности с указанным id в БД.</exception>
        public async Task<object> Update(Payment payment)
        {
            var paymentForUpdate = await dbContext.Payments.FirstOrDefaultAsync(x => x.Id == payment.Id)
                ?? throw new NotFoundException($"Оплата с идентификатором {payment.Id} не найдена.");

            if (payment.PaymentNumber != null && paymentForUpdate.PaymentNumber != payment.PaymentNumber) paymentForUpdate.PaymentNumber = payment.PaymentNumber;
            if (payment.PaymentStatus != null && paymentForUpdate.PaymentStatus != payment.PaymentStatus) paymentForUpdate.PaymentStatus = payment.PaymentStatus;
            if (payment.PaymentDate != null && paymentForUpdate.PaymentDate != payment.PaymentDate) paymentForUpdate.PaymentDate = payment.PaymentDate;
            if (payment.UserId != null && paymentForUpdate.UserId != payment.UserId) paymentForUpdate.UserId = payment.UserId;
            if (payment.ReservationId != null && paymentForUpdate.ReservationId != payment.ReservationId) paymentForUpdate.ReservationId = payment.ReservationId;
            if (payment.Amount != null && paymentForUpdate.Amount != payment.Amount) paymentForUpdate.Amount = payment.Amount;
            if (!string.IsNullOrWhiteSpace(payment.SenderBank) && paymentForUpdate.SenderBank != payment.SenderBank) paymentForUpdate.SenderBank = payment.SenderBank;
            if (!string.IsNullOrWhiteSpace(payment.SenderPaymentAccount) && paymentForUpdate.SenderPaymentAccount != payment.SenderPaymentAccount) paymentForUpdate.SenderPaymentAccount = payment.SenderPaymentAccount;
            if (!string.IsNullOrWhiteSpace(payment.RecipientBank) && paymentForUpdate.RecipientBank != payment.RecipientBank) paymentForUpdate.RecipientBank = payment.RecipientBank;
            if (!string.IsNullOrWhiteSpace(payment.RecipientPaymentAccount) && paymentForUpdate.RecipientPaymentAccount != payment.RecipientPaymentAccount) paymentForUpdate.RecipientPaymentAccount = payment.RecipientPaymentAccount;

            await dbContext.SaveChangesAsync();
            return new { Message = "OK" };
        }

        /// <summary>
        /// Функция проверки сущности Оплата (Payment) на уникальность при создании.
        /// </summary>
        /// <param name="payment">Оплата.</param>
        /// <returns>true или сообщение об ошибке.</returns>
        public async Task<bool> IsUnique(Payment payment)
        {
            if (await dbContext.Payments.AsNoTracking().AnyAsync(x => x.ReservationId == payment.ReservationId))
                throw new NotUniqueException($"К бронированию с ID {payment.ReservationId} уже привязана оплата.");
            return true;
        }

        /// <summary>
        /// Функция проверки сущности Оплата (Payment) на уникальность при изменении.
        /// </summary>
        /// <param name="payment">Оплата.</param>
        /// <returns>true или сообщение об ошибке.</returns>
        public async Task<bool> IsUniqueForUpdate(Payment payment)
        {
            if (payment.ReservationId != null
                && await dbContext.Payments.AsNoTracking().AnyAsync(x => x.ReservationId == payment.ReservationId && x.Id != payment.Id))
                throw new NotUniqueException($"К бронированию с ID {payment.ReservationId} уже привязана оплата.");
            return true;
        }
    }
}

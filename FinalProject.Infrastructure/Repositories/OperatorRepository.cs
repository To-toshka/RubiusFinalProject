using FinalProject.Application.Abstractions.Repositories;
using FinalProject.Application.Exceptions;
using FinalProject.Domain;
using Microsoft.EntityFrameworkCore;

namespace FinalProject.Infrastructure.Repositories
{
    /// <summary>
    /// Класс реализующий работу с сущностью Перевозчик (Operator) в БД.
    /// </summary>
    /// <param name="dbContext">Экземпляр класса CustomDbContext.</param>
    public class OperatorRepository(CustomDbContext dbContext) : IEntitiesRepository<Operator>
    {
        /// <summary>
        /// Создание новой сущности Перевозчик (Operator) в БД.
        /// </summary>
        /// <param name="newOperator">Сущность Перевозчик (Operator).</param>
        /// <returns>Id сущности.</returns>
        public async Task<long> Create(Operator newOperator)
        {
            dbContext.Operators.Add(newOperator);
            await dbContext.SaveChangesAsync();
            return newOperator.Id;
        }

        /// <summary>
        /// Удаление сущности Перевозчик (Operator) из БД.
        /// </summary>
        /// <param name="id">Уникальный идентификатор сущности.</param>
        /// <returns>Сообщение "OK" или сообщение об ошибке.</returns>
        /// <exception cref="NotFoundException">Ошибка возникающая при отсутсвии сущности с указанным id в БД.</exception>
        public async Task<object> Delete(long id)
        {
            int deletedRows = await dbContext.Operators.Where(x => x.Id == id).ExecuteDeleteAsync();
            if (deletedRows > 0)
            {
                return new { Message = "OK" };
            }
            else
            {
                throw new NotFoundException($"Перевозчик с идентификатором {id} не найден.");
            }
        }

        /// <summary>
        /// Получение сущности Перевозчик (Operator) из БД по id.
        /// </summary>
        /// <param name="id">Уникальный идентификатор сущности.</param>
        /// <returns>Сущности перевозчик (Operator).</returns>
        /// <exception cref="NotFoundException">Ошибка возникающая при отсутсвии сущности с указанным id в БД.</exception>
        public async Task<Operator> GetById(long id)
        {
            return await dbContext.Operators.FirstOrDefaultAsync(x => x.Id == id)
                ?? throw new NotFoundException($"Перевозчик с идентификатором {id} не найден.");
        }

        /// <summary>
        /// Получение списка всех сущностей Перевозчик (Operator) хранящихся в БД.
        /// </summary>
        /// <returns>Коллекция сущностей.</returns>
        public async Task<IReadOnlyCollection<Operator>> Get()
        {
            var result = await dbContext.Operators.ToListAsync();
            return result;
        }

        /// <summary>
        /// Изменение сущности Перевозчик (Operator) хранящейся в БД.
        /// </summary>
        /// <param name="newOperator">Новые данные для сущности Перевозчик (Operator).</param>
        /// <returns>Сообщение "OK" или сообщение об ошибке.</returns>
        /// <exception cref="NotFoundException">Ошибка возникающая при отсутсвии сущности с указанным id в БД.</exception>
        public async Task<object> Update(Operator newOperator)
        {
            var operatorForUpdate = await dbContext.Operators.FirstOrDefaultAsync(x => x.Id == newOperator.Id)
                ?? throw new NotFoundException($"Перевозчик с идентификатором {newOperator.Id} не найден.");

            if (!string.IsNullOrWhiteSpace(newOperator.Name) && operatorForUpdate.Name != newOperator.Name) operatorForUpdate.Name = newOperator.Name;
            if (!string.IsNullOrWhiteSpace(newOperator.Description) && operatorForUpdate.Description != newOperator.Description) operatorForUpdate.Description = newOperator.Description;
            if (!string.IsNullOrWhiteSpace(newOperator.Bank) && operatorForUpdate.Bank != newOperator.Bank) operatorForUpdate.Bank = newOperator.Bank;
            if (!string.IsNullOrWhiteSpace(newOperator.PaymentAccount) && operatorForUpdate.PaymentAccount != newOperator.PaymentAccount) operatorForUpdate.PaymentAccount = newOperator.PaymentAccount;

            await dbContext.SaveChangesAsync();
            return new { Message = "OK" };
        }

        /// <summary>
        /// Функция проверки сущности Перевозчик (Operator) на уникальность при создании.
        /// </summary>
        /// <param name="newOperator">Перевозчик.</param>
        /// <returns>true или сообщение об ошибке.</returns>
        public async Task<bool> IsUnique(Operator newOperator)
        {
            if (await dbContext.Operators.AsNoTracking().AnyAsync(x => x.Name == newOperator.Name)) throw new NotUniqueException($"Перевозчик с именем {newOperator.Name} уже зарегестрирован.");
            if (await dbContext.Operators.AsNoTracking().AnyAsync(x => x.PaymentAccount == newOperator.PaymentAccount)) throw new NotUniqueException($"Рассчетный счет {newOperator.PaymentAccount} уже зарегистрирован.");
            return true;
        }

        /// <summary>
        /// Функция проверки сущности Перевозчик (Operator) на уникальность при изменении.
        /// </summary>
        /// <param name="updataOperator">Перевозчик.</param>
        /// <returns>true или сообщение об ошибке.</returns>
        public async Task<bool> IsUniqueForUpdate(Operator updataOperator)
        {
            if (!string.IsNullOrWhiteSpace(updataOperator.Name)
                && await dbContext.Operators.AsNoTracking().AnyAsync(x => x.Name == updataOperator.Name && x.Id != updataOperator.Id))
                throw new NotUniqueException($"Перевозчик с именем {updataOperator.Name} уже зарегестрирован.");
            if (!string.IsNullOrWhiteSpace(updataOperator.PaymentAccount)
                && await dbContext.Operators.AnyAsync(x => x.PaymentAccount == updataOperator.PaymentAccount && x.Id != updataOperator.Id))
                throw new NotUniqueException($"Рассчетный счет {updataOperator.PaymentAccount} уже зарегистрирован.");
            return true;
        }
    }
}

using FinalProject.Application.Abstractions.Repositories;
using FinalProject.Application.Exceptions;
using FinalProject.Domain;
using Microsoft.EntityFrameworkCore;

namespace FinalProject.Infrastructure.Repositories
{
    /// <summary>
    /// Класс реализующий работу с сущностью Пользователь (User) в БД.
    /// </summary>
    /// <param name="dbContext">Экземпляр класса CustomDbContext.</param>
    public class UserRepository(CustomDbContext dbContext) : IEntitiesRepository<User>
    {
        /// <summary>
        /// Создание новой сущности Пользователь (User) в БД.
        /// </summary>
        /// <param name="user">Сущность Пользователь (User).</param>
        /// <returns>Id сущности.</returns>
        public async Task<long> Create(User user)
        {
            dbContext.Users.Add(user);
            await dbContext.SaveChangesAsync();
            return user.Id;
        }

        /// <summary>
        /// Удаление сущности Пользователь (User) из БД.
        /// </summary>
        /// <param name="id">Уникальный идентификатор сущности.</param>
        /// <returns>Сообщение "OK" или сообщение об ошибке.</returns>
        /// <exception cref="NotFoundException">Ошибка возникающая при отсутсвии сущности с указанным id в БД.</exception>
        public async Task<object> Delete(long id)
        {
            int deletedRows = await dbContext.Users.Where(x => x.Id == id).ExecuteDeleteAsync();
            if (deletedRows > 0)
            {
                return new { Message = "OK" };
            }
            else
            {
                throw new NotFoundException($"Пользователь с идентификатором {id} не найден.");
            }
        }

        /// <summary>
        /// Получение сущности Пользователь (User) из БД по id.
        /// </summary>
        /// <param name="id">Уникальный идентификатор сущности.</param>
        /// <returns>Сущности пользоватеь (User).</returns>
        /// <exception cref="NotFoundException">Ошибка возникающая при отсутсвии сущности с указанным id в БД.</exception>
        public async Task<User> GetById(long id)
        {
            return await dbContext.Users.FirstOrDefaultAsync(x => x.Id == id)
                ?? throw new NotFoundException($"Пользователь с идентификатором {id} не найден.");
        }

        /// <summary>
        /// Получение списка всех сущностей Пользователь (User) хранящихся в БД.
        /// </summary>
        /// <returns>Коллекция сущностей.</returns>
        public async Task<IReadOnlyCollection<User>> Get()
        {
            var result = await dbContext.Users.ToListAsync();
            return result;
        }

        /// <summary>
        /// Изменение сущности Пользователь (User) хранящейся в БД.
        /// </summary>
        /// <param name="user">Новые данные для сущности Пользователь (User).</param>
        /// <returns>Сообщение "OK" или сообщение об ошибке.</returns>
        /// <exception cref="NotFoundException">Ошибка возникающая при отсутсвии сущности с указанным id в БД.</exception>
        public async Task<object> Update(User user)
        {
            var userForUpdate = await dbContext.Users.FirstOrDefaultAsync(x => x.Id == user.Id)
                ?? throw new NotFoundException($"Пользователь с идентификатором {user.Id} не найден.");

            if (!string.IsNullOrWhiteSpace(user.Login) && userForUpdate.Login != user.Login) userForUpdate.Login = user.Login;
            if (!string.IsNullOrWhiteSpace(user.Password) && userForUpdate.Password != user.Password) userForUpdate.Password = user.Password;
            if (!string.IsNullOrWhiteSpace(user.Email) && userForUpdate.Email != user.Email) userForUpdate.Email = user.Email;
            if (user.BirthDate != null && userForUpdate.BirthDate != user.BirthDate) userForUpdate.BirthDate = user.BirthDate;
            await dbContext.SaveChangesAsync();
            return new { Message = "OK" };
        }
    }
}

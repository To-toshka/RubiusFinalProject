using FinalProject.Application.DTO;
using FinalProject.Domain;

namespace FinalProject.Application.Abstractions.Repositories
{
    /// <summary>
    /// Интерфейс для работы с сущностями в слое Infrastructure.
    /// </summary>
    public interface IEntitiesRepository<T> where T : BaseEntity
    {
        /// <summary>
        /// Получение списка сущностей.
        /// </summary>
        /// <returns>Коллекция сущностей</returns>
        Task<IReadOnlyCollection<T>> Get();

        /// <summary>
        /// Получение сущности по id.
        /// </summary>
        /// <param name="id">Уникальный идентификатор сущности.</param>
        /// <returns>Сущность.</returns>
        Task<T> GetById(long id);

        /// <summary>
        /// Создание сущности.
        /// </summary>
        /// <param name="t">Сущность.</param>
        /// <returns>Id сущности.</returns>
        Task<long> Create(T t);

        /// <summary>
        /// Изменение сущности.
        /// </summary>
        /// <param name="t">Сущность.</param>
        /// <returns>Сообщение "OK".</returns>
        Task<object> Update(T t);

        /// <summary>
        /// Удаление сущности.
        /// </summary>
        /// <param name="id">Уникальный идентификатор сущности.</param>
        /// <returns>Сообщение "OK".</returns>
        Task<object> Delete(long id);

        /// <summary>
        /// Проверка уникальности сущности при создании.
        /// </summary>
        /// <param name="t">Сущность.</param>
        /// <returns></returns>
        Task<bool> IsUnique(T t);

        /// <summary>
        /// Проверка уникальности сущности при изменении.
        /// </summary>
        /// <param name="t">Сущность.</param>
        /// <returns></returns>
        Task<bool> IsUniqueForUpdate(T t);
    }
}

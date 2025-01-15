using FinalProject.Application.DTO;

namespace FinalProject.Application.Abstractions.Services
{
    /// <summary>
    /// Интерфейс для работы с сущностями.
    /// </summary>
    public interface IEntitieService<T> where T : BaseDTO
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
        /// <param name="id">Уникальный идентификатор сущности.</param>
        /// <param name="t">Сущность.</param>
        /// <returns>Сообщение "OK".</returns>
        Task<object> Update(T t);

        /// <summary>
        /// Удаление сущности.
        /// </summary>
        /// <param name="id">Уникальный идентификатор сущности.</param>
        /// <returns>Сообщение "OK".</returns>
        Task<object> Delete(long id);
    }
}

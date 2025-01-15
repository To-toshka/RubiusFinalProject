using AutoMapper;
using FinalProject.Application.Abstractions.Repositories;
using FinalProject.Application.Abstractions.Services;
using FinalProject.Application.DTO;
using FinalProject.Domain;

namespace FinalProject.Application.Services
{
    /// <summary>
    /// Сервис для работы с сущностью Пользователь (User).
    /// </summary>
    /// <param name="userRepository">Экземпляр интерфейс для работы с сущностью в слое Infrastructure.</param>
    /// <param name="mapper">Экземпляр автомапера для конвертации сущностей.</param>
    public class UserService(IEntitiesRepository<User> userRepository, IMapper mapper) : IEntitieService<UserDTO>
    {
        /// <summary>
        /// Создание пользователя (User).
        /// </summary>
        /// <param name="user">Пользователь.</param>
        /// <returns>Id пользователя.</returns>
        public Task<long> Create(UserDTO user)
        {
            var entity = mapper.Map<User>(user);
            return userRepository.Create(entity);
        }

        /// <summary>
        /// Удаление пользователя (User).
        /// </summary>
        /// <param name="id">Уникальный идентификатор пользователя (User).</param>
        /// <returns>Сообщение "OK".</returns>
        public Task<object> Delete(long id)
        {
            return userRepository.Delete(id);
        }

        /// <summary>
        /// Получение пользователя (User) по id.
        /// </summary>
        /// <param name="id">Уникальный идентификатор пользователя (User).</param>
        /// <returns>Пользователь (User).</returns>
        public async Task<UserDTO> GetById(long id)
        {
            var result = await userRepository.GetById(id);
            return mapper.Map<UserDTO>(result);
        }

        /// <summary>
        /// Получение списка пользователей.
        /// </summary>
        /// <returns>Коллекция пользователей (Users)</returns>
        public async Task<IReadOnlyCollection<UserDTO>> Get()
        {
            var result = await userRepository.Get();
            return mapper.Map<IReadOnlyCollection<UserDTO>>(result);
        }

        /// <summary>
        /// Изменение пользователя (User).
        /// </summary>
        /// <param name="user">Пользователь.</param>
        /// <returns>Сообщение "OK".</returns>
        public Task<object> Update(UserDTO user)
        {
            var entity = mapper.Map<User>(user);
            return userRepository.Update(entity);
        }
    }
}

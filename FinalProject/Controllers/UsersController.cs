using FinalProject.Application.Abstractions.Services;
using FinalProject.Application.DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FinalProject.Controllers
{
    /// <summary>
    /// Контроллер Пользователей.
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController(IEntitieService<UserDTO> userService) : ControllerBase
    {
        /// <summary>
        /// Возвращает список Пользователей.
        /// </summary>
        /// <returns>Коллекция пользователей (Users).</returns>
        [HttpGet]
        public Task<IReadOnlyCollection<UserDTO>> Get()
        {
            return userService.Get();
        }

        /// <summary>
        /// Возвращает Пользователя по Id.
        /// </summary>
        /// <param name="id">Id пользователя.</param>
        /// <returns>Пользователь.</returns>
        [HttpGet("{id}/Info")]
        public Task<UserDTO> GetUserById(long id)
        {
            return userService.GetById(id);
        }

        /// <summary>
        /// Cоздает Пользователя.
        /// </summary>
        /// <param name="user">Пользователь.</param>
        /// <returns>Id пользователя.</returns>
        [HttpPost("Create")]
        public Task<long> Create(UserDTO user)
        {
            return userService.Create(user);
        }

        /// <summary>
        /// Обновляет Пользователя.
        /// </summary>
        /// <param name="user">Пользователь.</param>
        /// <returns>Сообщение "OK".</returns>
        [HttpPost("Update")]
        public Task<object> Update (UserDTO user)
        {
            return userService.Update(user);
        }

        /// <summary>
        /// Удаляе Пользователя.
        /// </summary>
        /// <param name="id">Id пользователя.</param>
        /// <returns>Сообщение "OK".</returns>
        [HttpPost("Delete")]
        public Task<object> Delete(long id)
        {
            return userService.Delete(id);
        }
    }
}

using FinalProject.Application.Abstractions.Services;
using FinalProject.Application.DTO;
using FinalProject.Application.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FinalProject.Api.Controllers
{
    /// <summary>
    /// Контроллер Перевозчиков.
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class OperatorsController(IEntitieService<OperatorDTO> operatorService) : ControllerBase
    {
        /// <summary>
        /// Возвращает список перевозчиков.
        /// </summary>
        /// <returns>Коллекция перевозчиков (Operators).</returns>
        [HttpGet]
        public Task<IReadOnlyCollection<OperatorDTO>> Get()
        {
            return operatorService.Get();
        }

        /// <summary>
        /// Возвращает Перевозчика по Id.
        /// </summary>
        /// <param name="id">Id перевозчика.</param>
        /// <returns>Перевозчик.</returns>
        [HttpGet("{id}/Info")]
        public Task<OperatorDTO> GetUserById(long id)
        {
            return operatorService.GetById(id);
        }

        /// <summary>
        /// Cоздает Перевозчика.
        /// </summary>
        /// <param name="newOperator">Перевозчик.</param>
        /// <returns>Id перевозчика.</returns>
        [HttpPost("Create")]
        public Task<long> Create(OperatorDTO newOperator)
        {
            return operatorService.Create(newOperator);
        }

        /// <summary>
        /// Обновляет Перевозчика.
        /// </summary>
        /// <param name="newOperator">Перевозчик.</param>
        /// <returns>Сообщение "OK".</returns>
        [HttpPost("Update")]
        public Task<object> Update(OperatorDTO newOperator)
        {
            return operatorService.Update(newOperator);
        }

        /// <summary>
        /// Удаляе Перевозчика.
        /// </summary>
        /// <param name="id">Id перевозчика.</param>
        /// <returns>Сообщение "OK".</returns>
        [HttpPost("Delete")]
        public Task<object> Delete(long id)
        {
            return operatorService.Delete(id);
        }
    }
}

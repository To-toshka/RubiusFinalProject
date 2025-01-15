using AutoMapper;
using FinalProject.Application.Abstractions.Repositories;
using FinalProject.Application.Abstractions.Services;
using FinalProject.Application.DTO;
using FinalProject.Domain;

namespace FinalProject.Application.Services
{
    /// <summary>
    /// Сервис для работы с сущностью Перевозчик (Operator).
    /// </summary>
    /// <param name="operatorRepository">Экземпляр интерфейс для работы с сущностью в слое Infrastructure.</param>
    /// <param name="mapper">Экземпляр автомапера для конвертации сущностей.</param>
    public class OperatorService(IEntitiesRepository<Operator> operatorRepository, IMapper mapper) : IEntitieService<OperatorDTO>
    {
        /// <summary>
        /// Создание перевозчика (Operator).
        /// </summary>
        /// <param name="newOperator">Перевозчик.</param>
        /// <returns>Id перевозчика.</returns>
        public Task<long> Create(OperatorDTO newOperator)
        {
            var entity = mapper.Map<Operator>(newOperator);
            return operatorRepository.Create(entity);
        }

        /// <summary>
        /// Удаление перевозчика (Operator).
        /// </summary>
        /// <param name="id">Уникальный идентификатор перевозчика (Operator).</param>
        /// <returns>Строка "OK".</returns>
        public Task<object> Delete(long id)
        {
            return operatorRepository.Delete(id);
        }

        /// <summary>
        /// Получение перевозчика (Operator) по id.
        /// </summary>
        /// <param name="id">Уникальный идентификатор перевозчика (Operator).</param>
        /// <returns>Перевозчик (Operator).</returns>
        public async Task<OperatorDTO> GetById(long id)
        {
            var result = await operatorRepository.GetById(id);
            return mapper.Map<OperatorDTO>(result);
        }

        /// <summary>
        /// Получение списка перевозчиков.
        /// </summary>
        /// <returns>Коллекция перевозчиков (Operators)</returns>
        public async Task<IReadOnlyCollection<OperatorDTO>> Get()
        {
            var result = await operatorRepository.Get();
            return mapper.Map<IReadOnlyCollection<OperatorDTO>>(result);
        }

        /// <summary>
        /// Изменение перевозчика (Operator).
        /// </summary>
        /// <param name="dataOperator">Перевозчик.</param>
        /// <returns>Сообщение "OK".</returns>
        public Task<object> Update(OperatorDTO dataOperator)
        {
            var entity = mapper.Map<Operator>(dataOperator);
            return operatorRepository.Update(entity);
        }
    }
}

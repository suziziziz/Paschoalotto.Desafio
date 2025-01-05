using Paschoalotto.Desafio.Domain.Entities;

namespace Paschoalotto.Desafio.Domain.Repositories;

public interface IRepository<T> where T : Entity
{
    Task<IEnumerable<T>> GetAllAsync();
    Task<T> GetByIdAsync();
    Task<T> UpdateAsync(T entity);
}

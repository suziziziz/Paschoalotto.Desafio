using Paschoalotto.Desafio.Domain.Entities;

namespace Paschoalotto.Desafio.Domain.Repositories;

public interface IRepository<T> where T : Entity
{
    Task<int> PageCountAsync();
    Task<IEnumerable<T>> GetAllAsync(int page = 1);
    Task<T?> GetByIdAsync(string id);
    Task<T?> UpdateAsync(T entity);
    Task<T?> CreateAsync(T entity);
}

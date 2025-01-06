using Paschoalotto.Desafio.Application.DTOs;

namespace Paschoalotto.Desafio.Application.Services;

public interface IService<T> where T : EntityDTO
{
    Task<int> PageCount();
    Task<IEnumerable<T>> FindAll(int page = 1);
    Task<T?> FindById(string id);
    Task<T?> Update(string id, T entity);
    Task<T?> Create(T entity);
}

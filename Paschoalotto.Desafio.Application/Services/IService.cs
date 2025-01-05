using Paschoalotto.Desafio.Application.DTOs;

namespace Paschoalotto.Desafio.Application.Services;

public interface IService<T> where T : EntityDTO
{
    Task<IEnumerable<T>> FindAll();
    Task<T?> FindById(string id);
    Task<T?> Update(string id, T entity);
}

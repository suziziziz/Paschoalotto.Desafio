using Paschoalotto.Desafio.Domain.Entities;

namespace Paschoalotto.Desafio.Domain.Repositories;

public interface IUserRepository : IRepository<User>
{
    Task<bool> IsDuplicated(User user);
}

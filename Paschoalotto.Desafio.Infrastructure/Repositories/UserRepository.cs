
using Microsoft.EntityFrameworkCore;

using Paschoalotto.Desafio.Domain.Entities;
using Paschoalotto.Desafio.Domain.Repositories;
using Paschoalotto.Desafio.Infrastructure.Context;

namespace Paschoalotto.Desafio.Infrastructure.Repositories;

public class UserRepository(DesafioDbContext db) : IUserRepository
{
    private readonly DesafioDbContext _db = db;

    public async Task<IEnumerable<User>> GetAllAsync()
    {
        var users = await _db.Users.AsNoTracking()
            .Where(x => x.DeletedAt == null)
            .ToListAsync();

        return users;
    }

    public async Task<User?> GetByIdAsync(string id)
    {
        var user = await _db.Users.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);

        return user;
    }

    public async Task<User?> UpdateAsync(User entity)
    {
        entity.UpdatedAt = DateTime.UtcNow;

        _db.Entry(entity).State = EntityState.Modified;
        await _db.SaveChangesAsync();

        return entity;
    }

    public async Task<User?> CreateAsync(User entity)
    {
        entity.CreatedAt = DateTime.UtcNow;
        entity.UpdatedAt = DateTime.UtcNow;
        entity.Id = Guid.NewGuid().ToString();

        _db.Entry(entity).State = EntityState.Added;
        await _db.SaveChangesAsync();

        return entity;
    }

    public async Task<bool> IsDuplicated(User user)
    {
        var finded = await _db.Users.AsNoTracking()
            .FirstOrDefaultAsync(x => x.Id != user.Id && (x.Username == user.Username || x.Email == user.Email));

        return finded != null;
    }
}

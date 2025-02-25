using System.Security.Cryptography;

using Microsoft.EntityFrameworkCore;

using Paschoalotto.Desafio.Domain.Entities;
using Paschoalotto.Desafio.Domain.Repositories;
using Paschoalotto.Desafio.Infrastructure.Context;
using Paschoalotto.Desafio.Infrastructure.Helpers;

namespace Paschoalotto.Desafio.Infrastructure.Repositories;

public class UserRepository(DesafioDbContext db) : IUserRepository
{
    private readonly DesafioDbContext _db = db;

    private const int PageSize = 50;

    public async Task<int> PageCountAsync()
    {
        return await _db.Users.AsNoTracking()
            .OrderBy(x => x.FullName)
            .Where(x => x.DeletedAt == null)
            .CountAsync() / PageSize;
    }

    public async Task<IEnumerable<User>> GetAllAsync(int page = 1)
    {
        var users = await _db.Users.AsNoTracking()
            .OrderBy(x => x.FullName)
            .Skip((page - 1) * PageSize)
            .Take(PageSize)
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
        HashPassword(entity);
        entity.UpdatedAt = DateTime.UtcNow;

        _db.Entry(entity).State = EntityState.Modified;
        await _db.SaveChangesAsync();

        return entity;
    }

    public async Task<User?> CreateAsync(User entity)
    {
        HashPassword(entity);
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

    private static void HashPassword(User user)
    {
        var salt = RandomNumberGenerator.GetBytes(128 / 8);
        user.Salt ??= Convert.ToBase64String(salt);
        user.Password = PasswordHashHelper.Hash(user.Password!, salt);
    }
}

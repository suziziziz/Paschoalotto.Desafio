using Paschoalotto.Desafio.Domain.Validations;

namespace Paschoalotto.Desafio.Domain.Entities;

public class User : Entity
{
    public string FullName { get; private set; }
    public string Username { get; private set; }
    public string Email { get; private set; }
    public string Password { get; private set; }
    public string? Picture { get; private set; }

    public User(
        string id,
        DateTime createdAt,
        DateTime updatedAt,
        string fullName,
        string username,
        string email,
        string password,
        string? picture) : base(id, createdAt, updatedAt)
    {
        FullName = fullName;
        Username = username;
        Email = email;
        Password = password;
        Picture = picture;

        DomainUserValidation.When(this);
    }
}

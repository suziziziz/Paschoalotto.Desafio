namespace Paschoalotto.Desafio.Domain.Entities;

public class Entity(string id, DateTime createdAt, DateTime updatedAt)
{
    public string Id { get; set; } = id;

    public DateTime CreatedAt { get; set; } = createdAt;
    public DateTime UpdatedAt { get; set; } = updatedAt;
    public DateTime? DeletedAt { get; set; }
}

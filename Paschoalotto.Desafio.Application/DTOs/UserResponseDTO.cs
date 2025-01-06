namespace Paschoalotto.Desafio.Application.DTOs;

public class UserResponseDTO : EntityDTO
{
    public string? FullName { get; set; }
    public string? Username { get; set; }
    public string? Email { get; set; }
    public string? Picture { get; set; }
}

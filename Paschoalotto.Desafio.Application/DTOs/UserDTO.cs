namespace Paschoalotto.Desafio.Application.DTOs;

public class UserDTO : EntityDTO
{
    public string? FullName { get; set; }
    public string? Username { get; set; }
    public string? Email { get; set; }
    public string? Password { get; set; }
    public string? Picture { get; set; }
}

namespace Paschoalotto.Desafio.Api.Models;

public class ResponseModel
{
    public dynamic? Data { get; set; }
    public int Page { get; set; } = 1;
    public int PageCount { get; set; } = 1;
    public string? ErrorMessage { get; set; }
}

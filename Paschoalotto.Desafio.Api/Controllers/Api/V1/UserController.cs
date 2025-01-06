using Microsoft.AspNetCore.Mvc;

using Paschoalotto.Desafio.Application.DTOs;

using Paschoalotto.Desafio.Application.Services;
using Paschoalotto.Desafio.Domain.Exceptions;

namespace Paschoalotto.Desafio.Api.Controllers.Api.V1;

[ApiController]
[Route("api/v1/[controller]")]
public class UserController(IUserService service) : ControllerBase
{
    private readonly IUserService _service = service;

    [HttpGet()]
    public async Task<ActionResult<IEnumerable<UserDTO>>> Get()
    {
        var users = await _service.FindAll();

        return Ok(users);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<UserDTO>> Get(string id)
    {
        var entity = await _service.FindById(id);

        return entity == null ? NotFound() : Ok(entity);
    }

    [HttpPut("{id}")]
    public async Task<ActionResult<UserDTO>> Put(string id, UserDTO model)
    {
        try
        {
            var entity = await _service.Update(id, model);

            return entity != null ? Ok(entity) : BadRequest("Não foi possível atualizar o usuário!");
        }
        catch (DomainEntityException e) { return BadRequest(e.Message); }
    }

    [HttpPost()]
    public async Task<ActionResult<UserDTO>> Post(UserDTO model)
    {
        try
        {
            var entity = await _service.Create(model);

            return entity != null ? Ok(entity) : BadRequest("Não foi possível criar o usuário!");
        }
        catch (DomainEntityException e) { return BadRequest(e.Message); }
    }
}
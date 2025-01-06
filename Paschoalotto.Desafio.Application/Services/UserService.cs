
using AutoMapper;

using Paschoalotto.Desafio.Application.DTOs;
using Paschoalotto.Desafio.Domain.Entities;
using Paschoalotto.Desafio.Domain.Exceptions;
using Paschoalotto.Desafio.Domain.Repositories;

namespace Paschoalotto.Desafio.Application.Services;

public class UserService(IUserRepository user, IMapper mapper) : IUserService
{
    private readonly IUserRepository _user = user;
    private readonly IMapper _mapper = mapper;

    public async Task<IEnumerable<UserDTO>> FindAll()
    {
        var users = await _user.GetAllAsync();

        return _mapper.Map<IEnumerable<UserDTO>>(users);
    }

    public async Task<UserDTO?> FindById(string id)
    {
        var user = await _user.GetByIdAsync(id);
        var entityDTO = _mapper.Map<UserDTO>(user);

        return entityDTO;
    }

    public async Task<UserDTO?> Update(string id, UserDTO entity)
    {
        entity.Id = id;
        var user = _mapper.Map<User>(entity);

        await VerifyDuplicate(user);

        var updatedEntity = await _user.UpdateAsync(user);

        return _mapper.Map<UserDTO>(updatedEntity);
    }

    public async Task<UserDTO?> Create(UserDTO entity)
    {
        var user = _mapper.Map<User>(entity);

        await VerifyDuplicate(user);

        var createdEntity = await _user.CreateAsync(user);

        return _mapper.Map<UserDTO>(createdEntity);
    }

    private async Task VerifyDuplicate(User user)
    {
        if (await _user.IsDuplicated(user)) throw new BadRequestException("Usuário duplicado");
    }
}

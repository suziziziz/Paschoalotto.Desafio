using AutoMapper;

using Paschoalotto.Desafio.Application.DTOs;
using Paschoalotto.Desafio.Domain.Entities;

namespace Paschoalotto.Desafio.Application.Mappings;

public class DomainToDTOMappingProfile : Profile
{
    public DomainToDTOMappingProfile()
    {
        CreateMap<User, UserDTO>().ReverseMap();
        CreateMap<UserDTO, UserResponseDTO>().ReverseMap();
        CreateMap<User, UserResponseDTO>().ReverseMap();
    }
}

using dotenv.net;
using dotenv.net.Utilities;

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

using Paschoalotto.Desafio.Application.Mappings;
using Paschoalotto.Desafio.Application.Services;
using Paschoalotto.Desafio.Domain.Repositories;
using Paschoalotto.Desafio.Infrastructure.Context;
using Paschoalotto.Desafio.Infrastructure.Repositories;

namespace Paschoalotto.Desafio.Infrastructure.Dependencies;

public static class InjectDependencies
{
    public static IServiceCollection AddDependencies(
        this IServiceCollection services,
        IConfiguration configuration)
    {
        services.AddDbContext<DesafioDbContext>();

        services.AddScoped<IUserRepository, UserRepository>();

        services.AddScoped<IUserService, UserService>();

        services.AddAutoMapper(typeof(DomainToDTOMappingProfile));

        return services;
    }
}

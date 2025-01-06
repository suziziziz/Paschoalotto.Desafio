using Microsoft.EntityFrameworkCore;

using Paschoalotto.Desafio.Domain.Entities;
using Paschoalotto.Desafio.Infrastructure.Context;
using Paschoalotto.Desafio.Infrastructure.Repositories;
using Paschoalotto.Desafio.Seeder;

using RestSharp;

static async Task<UsersModel?> GetManyUsers()
{
    var apiUrl = "https://randomuser.me/api/?results=100"
        + "&inc=name,email,login,picture"
        + "&password=special,upper,lower,number,8-32";
    var options = new RestClientOptions(apiUrl);
    var client = new RestClient(options);
    var response = await client.GetAsync<UsersModel>(new RestRequest());

    return response;
}

static async Task Run()
{
    using var db = new DesafioDbContext(new DbContextOptions<DesafioDbContext>());

    var userRepo = new UserRepository(db);

    var users = await GetManyUsers();

    if (users?.Results != null)
        foreach (var user in users.Results)
        {
            var insertedUser = await userRepo.CreateAsync(new User(
                id: "",
                createdAt: DateTime.UtcNow,
                updatedAt: DateTime.UtcNow,
                fullName: user.Name?.First + " " + user.Name?.Last,
                username: user.Login?.Username ?? "",
                email: user.Email ?? "",
                password: user.Login?.Password ?? "",
                picture: user.Picture?.Large ?? ""
            ));

            Console.WriteLine($"Usuário inserido: {insertedUser?.Username}");
        }
}

Run().Wait();

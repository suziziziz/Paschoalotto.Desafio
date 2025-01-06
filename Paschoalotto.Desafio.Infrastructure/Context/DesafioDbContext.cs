using dotenv.net;
using dotenv.net.Utilities;

using Microsoft.EntityFrameworkCore;

using Paschoalotto.Desafio.Domain.Entities;

namespace Paschoalotto.Desafio.Infrastructure.Context;

public class DesafioDbContext(DbContextOptions<DesafioDbContext> options) : DbContext(options)
{
    public DbSet<User> Users { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(DesafioDbContext).Assembly);
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        base.OnConfiguring(optionsBuilder);

        DotEnv.Load(new DotEnvOptions(envFilePaths: ["../.env", ".env"]));

        var connectionString = EnvReader.GetStringValue("DESAFIODB_CONNECTION_STRING");

        optionsBuilder.UseNpgsql(connectionString);
    }
}

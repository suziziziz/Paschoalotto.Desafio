FROM mcr.microsoft.com/dotnet/runtime:8.0 AS base
WORKDIR /app

USER app
FROM --platform=$BUILDPLATFORM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG configuration=Release
WORKDIR /src
COPY ["Paschoalotto.Desafio.Seeder/Paschoalotto.Desafio.Seeder.csproj", "Paschoalotto.Desafio.Seeder/"]
RUN dotnet restore "Paschoalotto.Desafio.Seeder/Paschoalotto.Desafio.Seeder.csproj"
COPY . .
WORKDIR "/src/Paschoalotto.Desafio.Seeder"
RUN dotnet build "Paschoalotto.Desafio.Seeder.csproj" -c $configuration -o /app/build

FROM build AS publish
ARG configuration=Release
RUN dotnet publish "Paschoalotto.Desafio.Seeder.csproj" -c $configuration -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Paschoalotto.Desafio.Seeder.dll", "true"]

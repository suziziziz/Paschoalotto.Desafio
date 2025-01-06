FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 8080

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG configuration=Release
WORKDIR /src
COPY ["Paschoalotto.Desafio.Api/Paschoalotto.Desafio.Api.csproj", "Paschoalotto.Desafio.Api/"]
RUN dotnet restore "Paschoalotto.Desafio.Api/Paschoalotto.Desafio.Api.csproj"
COPY . .
WORKDIR "/src/Paschoalotto.Desafio.Api"
RUN dotnet build "Paschoalotto.Desafio.Api.csproj" -c $configuration -o /app/build

FROM build AS publish
ARG configuration=Release
RUN dotnet publish "Paschoalotto.Desafio.Api.csproj" -c $configuration -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Paschoalotto.Desafio.Api.dll"]

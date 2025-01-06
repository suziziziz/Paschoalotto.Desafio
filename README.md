# Desafio

## Setup Development

### Banco de dados

Rode `docker-compose -f docker-compose.dev.yml up database --build` no terminal para inicializar o banco de dados.

### Pré-configuração da API

Antes de rodar a API, duplique o arquivo [.env.example](.env.example) localizado na raiz da aplicação, a configuração padrão já possíbilita a conexão com o banco de dados que está rodando em Docker.

### Populando Usuários

Apenas rode `dotnet run --project Paschoalotto.Desafio.Seeder` no terminal.

### Rodando API

Rode `dotnet run --project Paschoalotto.Desafio.Api` no terminal.

### Pré-configuração do Front-End

Entre na pasta `Paschoalotto.Desafio.Web`.

Duplique o arquivo [.env.example](Paschoalotto.Desafio.Web/.env.example) localizado na raiz do projeto `Web`, a configuração padrão já possíbilita a conexão com a api.

### Rodando Front-End

Entre na pasta `Paschoalotto.Desafio.Web`.

Rode `pnpm install` ou outro gerenciador de pacotes do Node, então rode `pnpm dev`.

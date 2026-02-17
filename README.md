# Stocker API
API para cadastro de produtos feito usando arquitetura Minimal API. Desenvolvida em C# com ASP.NET Core e Entity Framework.

## Tecnologias Utilizadas
- ASP.NET Core Web API Minimal API
- Entity Framework Core
- SQLite

### Pré-requisitos
- [.NET SDK 10+](https://dotnet.microsoft.com/download)
- [SQLite](https://www.microsoft.com/pt-br/sql-server/)
- [Git](https://git-scm.com/)

### Passos para rodar localmente
1. Clone o repositório:
   ```bash
   https://github.com/FelipeCostaq/Stocker.git
   cd stocker

2. Restaure as depêndencias.
   ```bash
   dotnet restore

3. Crie o banco de dados e rode as migrations.
   ```bash
   dotnet ef database update

4. Execute a aplicação
   ```bash
   dotnet run

# Endpoints

## Products

- **POST** `/products` – Adiciona um produto.
- **GET** `/products` – Lista todos produtos.
- **GET** `/products/{id}` – Busca um produto por Id.
- **PUT** `/products/{id}` – Editar um produto.
- **DELETE** `/products/{id}` – Remove um produto.

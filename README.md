# Sistema de Gestão de Franquias

API REST desenvolvida em C# / ASP.NET Core Web API para centralizar a gestão de uma rede de franquias — unidades, produtos, estoque, vendas, royalties e chamados de suporte.

## Objetivo

Fornecer uma API capaz de administrar usuários e perfis de acesso, unidades franqueadas, catálogo de produtos/serviços, estoque, vendas, cálculo de royalties, fornecedores, chamados de suporte e indicadores gerenciais — substituindo controles manuais e planilhas isoladas.

## Tecnologias utilizadas

- **C# / .NET 10** — ASP.NET Core Web API
- **Entity Framework Core** — acesso e persistência de dados
- **SQL Server** — banco de dados relacional
- **JWT (JSON Web Token)** — autenticação e autorização por perfil
- **BCrypt.Net** — hash de senhas
- **Swagger / OpenAPI** — documentação e testes dos endpoints

## Arquitetura

O projeto segue separação em camadas:

```
Controllers/   → recebe requisições HTTP e devolve respostas
Services/      → regras de negócio
Repositories/  → acesso a dados via Entity Framework Core
Models/        → entidades do domínio
DTOs/          → objetos de entrada e saída da API
Data/          → contexto do banco de dados (AppDbContext)
Migrations/    → histórico de alterações do banco
```

## Módulos implementados

- Autenticação (login, registro, JWT, perfis de acesso)
- Franqueadoras
- Unidades Franqueadas (com edição e inativação)
- Categorias
- Produtos/Serviços (com edição e inativação)
- Fornecedores
- Estoque (com bloqueio de saldo negativo e movimentações)
- Vendas (cálculo automático de total e baixa de estoque)
- Royalties (cálculo sobre faturamento por período)
- Chamados de suporte
- Relatórios: faturamento por unidade, ranking de unidades, produtos mais vendidos, estoque crítico, chamados por status

## Requisitos para execução

- [.NET SDK 10.0](https://dotnet.microsoft.com/download) ou superior
- SQL Server (local ou instância acessível)

## Como executar

1. Clone o repositório:
   ```
   git clone https://github.com/LuizHenriqueBarbosaBrito/sistema-gestao-franquias.git
   cd sistema-gestao-franquias
   ```

2. Ajuste a string de conexão em `appsettings.json` se necessário (por padrão aponta para `localhost`):
   ```json
   "ConnectionStrings": {
     "DefaultConnection": "Server=localhost;Database=FranquiasDb;Trusted_Connection=True;TrustServerCertificate=True"
   }
   ```

3. Aplique as migrations para criar o banco de dados:
   ```
   dotnet ef database update
   ```

4. Rode a aplicação:
   ```
   dotnet run
   ```

5. Acesse a documentação interativa da API:
   ```
   http://localhost:5263/swagger
   ```

## Autenticação

Ao rodar a API pela primeira vez, os perfis padrão (Administrador, Gestor, Operador) são criados automaticamente.

Para testar os endpoints protegidos:

1. Registre um usuário administrador em `POST /api/auth/registrar` (perfilId: 1).
2. Faça login em `POST /api/auth/login` para obter o token JWT.
3. No Swagger, clique em **Authorize** e cole o token no formato `Bearer {token}`.

## Autor

Luiz Henrique Barbosa Brito

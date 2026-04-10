# TaskBoard – Desafio Técnico Avanade

Aplicação de gerenciamento de tarefas estilo Kanban (inspirado no Trello/Jira), desenvolvida com Angular 17 no front-end e ASP.NET Core 8 Web API no back-end.

## Tecnologias

- **Front-end:** Angular 17 (Standalone Components)
- **Back-end:** ASP.NET Core 8 Web API (C#)
- **Banco de dados:** SQL Server
- **ORM:** Entity Framework Core 8
- **Comunicação:** REST API (JSON)

## Funcionalidades

- Board Kanban com 3 colunas: **Pendente**, **Em Andamento**, **Concluída**
- Criar, editar e excluir tarefas
- Mover tarefas entre colunas com um clique
- Prioridade por tarefa (Alta / Média / Baixa) com indicação visual
- Filtro por prioridade
- Validação de formulário
- Mensagens de sucesso/erro (toast)
- Contador de progresso no header

---

## Como rodar o projeto

### Opção 1 — Docker (recomendado)

Pré-requisito: [Docker Desktop](https://www.docker.com/products/docker-desktop/) instalado.

```bash
docker-compose up --build
```

Isso sobe três containers:
- `sqlserver` — SQL Server 2022 Express na porta 1433
- `api` — ASP.NET Core API na porta 5000 (migrations aplicadas automaticamente na inicialização)
- `frontend` — Angular servido via nginx na porta 4200

Acesse em `http://localhost:4200`  
Swagger UI: `http://localhost:5000/swagger`

Para derrubar tudo:
```bash
docker-compose down
```

Para derrubar e apagar o volume do banco:
```bash
docker-compose down -v
```

---

### Opção 2 — Execução local

#### Pré-requisitos

- [.NET 8 SDK](https://dotnet.microsoft.com/download)
- [Node.js 18+](https://nodejs.org/) e npm
- [Angular CLI](https://angular.io/cli): `npm install -g @angular/cli`
- SQL Server (local ou Docker)

---

#### 1. Back-end (API)

```bash
cd backend/TaskManager.API

# Restaurar pacotes
dotnet restore

# Aplicar migrations
dotnet ef database update

# Rodar a API
dotnet run
```

A API estará disponível em `http://localhost:5000`  
Swagger UI: `http://localhost:5000/swagger`

> Se precisar ajustar a connection string, edite `appsettings.json`:
> ```json
> "DefaultConnection": "Server=localhost;Database=TaskManagerDB;Trusted_Connection=True;TrustServerCertificate=True;"
> ```

---

#### 2. Front-end (Angular)

```bash
cd frontend

# Instalar dependências
npm install

# Rodar o servidor de desenvolvimento
ng serve
```

Acesse em `http://localhost:4200`

---

## Testes

```bash
cd backend
dotnet test TaskManager.Tests/TaskManager.Tests.csproj
```

Os testes usam EF Core InMemory — sem necessidade de banco de dados. Cobrem:
- `TarefaService` — todos os métodos (GetAll, GetById, Create, Update, UpdateStatus, Delete)
- `TarefasController` — status codes HTTP de cada endpoint
- `ServiceResult` — comportamento de Ok, Created, NotFound, BadRequest, InternalError

---

## Endpoints da API

| Método | Rota | Descrição |
|--------|------|-----------|
| GET | `/api/tarefas` | Listar todas (aceita `?status=Pendente`) |
| GET | `/api/tarefas/{id}` | Buscar por ID |
| POST | `/api/tarefas` | Criar tarefa |
| PUT | `/api/tarefas/{id}` | Atualizar tarefa |
| PATCH | `/api/tarefas/{id}/status` | Atualizar apenas o status |
| DELETE | `/api/tarefas/{id}` | Excluir tarefa |

---

## Estrutura do projeto

```
├── backend/
│   └── TaskManager.API/
│       ├── Controllers/       # TarefasController
│       ├── Services/          # TarefaService — lógica de negócio
│       ├── Models/            # Tarefa — entidade / modelo EF Core
│       ├── DTOs/              # CreateTarefaDto, UpdateTarefaDto, UpdateStatusDto, TarefaResponseDto
│       ├── Data/
│       │   ├── AppDbContext.cs
│       │   └── Migrations/
│       ├── Common/            # ServiceResult — wrapper de resposta com StatusCode
│       └── Program.cs
│
└── frontend/
    └── src/app/
        ├── components/
        │   ├── kanban-board/  # Tela principal com as colunas
        │   ├── task-card/     # Card individual de tarefa
        │   └── task-modal/    # Modal de criação/edição
        ├── models/            # Interfaces TypeScript
        └── services/          # TarefaService (HttpClient)
```

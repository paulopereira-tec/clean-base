# CleanBase API Solution

This is a **Clean Architecture** template for ASP.NET Core Web API projects. It is designed to be a robust starting point for enterprise applications, following best practices like **SOLID**, **DDD**, and **CQRS**.

## Structure / Estrutura

- **CleanBase.Api**: Entry point of the application. Contains Controllers, Configuration, and Middleware.
- **CleanBase.Business**: Application Layer. Contains the Business Logic, specific Features (CQRS), and Interfaces.
- **CleanBase.Domain**: Core Layer. Contains Entities, Enums, and Domain Logic. No external dependencies.
- **CleanBase.Infrastructure**: Infrastructure Layer. Contains Database Context and External Service Implementations.
- **CleanBase.Repository**: Persistence Layer. Implementations of Repositories.
- **CleanBase.Shared**: Shared Kernel. Common logic like Result pattern and Base Entities.

## Technologies / Tecnologias

- .NET 8
- Entity Framework Core (InMemory Configured)
- MediatR (CQRS)
- FluentValidation
- Hangfire (Background Jobs)
- SignalR (Real-time Notifications)
- Swagger (Documentation)

## How to Run / Como Rodar

1. **Restore Dependencies**: `dotnet restore`
2. **Run the API**: `dotnet run --project CleanBase.Api`
3. **Open Swagger**: Check the console output for the URL (e.g. `http://localhost:5000/swagger`)
4. **Hangfire Dashboard**: Navigate to `/hangfire` (e.g. `http://localhost:5000/hangfire`)

## Features Implemented / Funcionalidades Implementadas

- **To Do List**: Complete CRUD using CQRS.
- **Background Jobs**: Example of a recurring job running every minute.
- **Real-time Notifications**: Notify client when a task is completed.

For detailed tutorials, check the other Markdown files in this folder.
Para tutoriais detalhados, verifique os outros arquivos Markdown nesta pasta.

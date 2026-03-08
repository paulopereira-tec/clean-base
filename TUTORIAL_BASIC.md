# Tutorial: How to Create a Feature / Como Criar uma Funcionalidade

This tutorial explains how to add a new feature following the Clean Architecture and CQRS patterns used in this solution.
Este tutorial explica como adicionar uma nova funcionalidade seguindo os padrões Clean Architecture e CQRS usados nesta solução.

## 1. Domain Layer (CleanBase.Domain)
Start by defining your entity.
Comece definindo sua entidade.

Example: `Entities/MyEntity.cs`
```csharp
public class MyEntity : Entity
{
    public string Name { get; private set; }
    // Constructor and Methods...
}
```

## 2. Infrastructure (CleanBase.Infrastructure)
Add the entity to the `ApplicationDbContext` and create a Configuration.
Adicione a entidade ao `ApplicationDbContext` e crie uma Configuration.

Example: `Data/Configurations/MyEntityConfiguration.cs`

## 3. Business Layer (CleanBase.Business)
Create a new folder in `Features`. Define the Command/Query, Handler, and Validator.
Crie uma nova pasta em `Features`. Defina o Command/Query, Handler e Validator.

**Structure**:
- Features/MyFeature/CreateMyEntity/
    - `CreateMyEntityCommand.cs` (Inputs)
    - `CreateMyEntityHandler.cs` (Logic)
    - `CreateMyEntityValidator.cs` (Validation)

**The Handler**:
1. Validate input (handled by pipeline). (Validação automática pelo pipeline)
2. Create the Entity. (Cria a Entidade)
3. Call Repository to save. (Chama Repositório para salvar)
4. Return `Result<T>`. (Retorna Result)

## 4. API Layer (CleanBase.Api)
Create a Controller endpoint to call the Mediator.
Crie um endpoint no Controller para chamar o Mediator.

```csharp
[HttpPost]
public async Task<IActionResult> Create(CreateMyEntityCommand command)
{
    var result = await _mediator.Send(command);
    return Ok(result);
}
```

## Tips / Dicas
- Always use the `Result` pattern to return data or errors. (Sempre use o padrão Result)
- Keep Handlers focused on a single task. (Mantenha Handlers focados em uma única tarefa)
- Use `INotifier` if you need to send real-time updates. (Use INotifier para updates em tempo real)

using CleanBase.Domain.Entities;
using CleanBase.Domain.Interfaces;
using CleanBase.Shared;
using MediatR;

namespace CleanBase.Business.Features.ToDoItems.CreateToDoItem
{
  /// <summary>
  /// Handler for processing the CreateToDoItemCommand.
  /// Handler para processar o comando de criação.
  /// </summary>
  public class CreateToDoItemHandler : IRequestHandler<CreateToDoItemCommand, Result<Guid>>
  {
    private readonly IToDoRepository _repository;

    public CreateToDoItemHandler(IToDoRepository repository)
    {
      _repository = repository;
    }

    public async Task<Result<Guid>> Handle(CreateToDoItemCommand request, CancellationToken cancellationToken)
    {
      // Create the entity
      // Cria a entidade
      var todoItem = new ToDoItem(request.Title, request.Description);

      // Persist
      // Persiste no banco
      await _repository.AddAsync(todoItem);

      // Return success with ID
      // Retorna sucesso com o ID
      return Result<Guid>.Ok(todoItem.Id);
    }
  }
}

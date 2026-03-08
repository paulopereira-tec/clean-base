using CleanBase.Domain.Entities;
using CleanBase.Domain.Interfaces;
using CleanBase.Shared;
using MediatR;

namespace CleanBase.Business.Features.ToDoItems.GetToDoItems
{
  /// <summary>
  /// Handler for processing GetToDoItemsQuery.
  /// Handler para processar a consulta de listagem.
  /// </summary>
  public class GetToDoItemsHandler : IRequestHandler<GetToDoItemsQuery, Result<List<ToDoItem>>>
  {
    private readonly IToDoRepository _repository;

    public GetToDoItemsHandler(IToDoRepository repository)
    {
      _repository = repository;
    }

    public async Task<Result<List<ToDoItem>>> Handle(GetToDoItemsQuery request, CancellationToken cancellationToken)
    {
      var items = await _repository.GetAllAsync();
      return Result<List<ToDoItem>>.Ok(items);
    }
  }
}

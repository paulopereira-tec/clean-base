using CleanBase.Domain.Entities;
using CleanBase.Shared;
using MediatR;

namespace CleanBase.Business.Features.ToDoItems.GetToDoItems
{
  /// <summary>
  /// Query to get all ToDo items.
  /// Consulta para obter todos os itens ToDo.
  /// </summary>
  public class GetToDoItemsQuery : IRequest<Result<List<ToDoItem>>>
  {
  }
}

using CleanBase.Shared;
using MediatR;

namespace CleanBase.Business.Features.ToDoItems.CompleteToDoItem
{
  /// <summary>
  /// Command to mark a ToDo Item as complete.
  /// Comando para marcar um item ToDo como concluído.
  /// </summary>
  public class CompleteToDoItemCommand : IRequest<Result>
  {
    public Guid Id { get; set; }
  }
}

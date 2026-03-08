using CleanBase.Shared;
using MediatR;

namespace CleanBase.Business.Features.ToDoItems.CreateToDoItem
{
  /// <summary>
  /// Command to create a new ToDo Item.
  /// Comando para criar um novo item ToDo.
  /// </summary>
  public class CreateToDoItemCommand : IRequest<Result<Guid>>
  {
    public string Title { get; set; }
    public string Description { get; set; }
  }
}

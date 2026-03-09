using CleanBase.Domain.Entities;

namespace CleanBase.Domain.Interfaces
{
  /// <summary>
  /// Repository interface for ToDoItem entity.
  /// Interface de repositório para a entidade ToDoItem.
  /// </summary>
  public interface IToDoRepository: IRepository<ToDoItem>
  {
    Task<List<ToDoItem>> GetAllAsync(CancellationToken cancellationToken);
  }
}

using CleanBase.Domain.Entities;

namespace CleanBase.Domain.Interfaces
{
  /// <summary>
  /// Repository interface for ToDoItem entity.
  /// Interface de repositório para a entidade ToDoItem.
  /// </summary>
  public interface IToDoRepository
  {
    Task<ToDoItem?> GetByIdAsync(Guid id);
    Task<List<ToDoItem>> GetAllAsync();
    Task AddAsync(ToDoItem item);
    Task UpdateAsync(ToDoItem item);
    Task DeleteAsync(Guid id);
  }
}

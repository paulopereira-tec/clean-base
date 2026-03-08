using CleanBase.Domain.Enums;
using CleanBase.Shared;

namespace CleanBase.Domain.Entities
{
  /// <summary>
  /// Represents a ToDo item in the system.
  /// Representa um item ToDo no sistema.
  /// </summary>
  public class ToDoItem : Entity
  {
    public string Title { get; private set; }
    public string Description { get; private set; }
    public ToDoStatus Status { get; private set; }
    public DateTime? CompletedAt { get; private set; }

    // EF Core Constructor
    protected ToDoItem() { }

    public ToDoItem(string title, string description)
    {
      Title = title;
      Description = description;
      Status = ToDoStatus.Pending;
    }

    public void MarkAsDone()
    {
      Status = ToDoStatus.Done;
      CompletedAt = DateTime.UtcNow;
    }

    public void Update(string title, string description)
    {
      Title = title;
      Description = description;
    }
  }
}

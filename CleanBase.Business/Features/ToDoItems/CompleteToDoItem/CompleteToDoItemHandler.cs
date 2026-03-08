using CleanBase.Business.Interfaces;
using CleanBase.Domain.Interfaces;
using CleanBase.Shared;
using MediatR;

namespace CleanBase.Business.Features.ToDoItems.CompleteToDoItem
{
  /// <summary>
  /// Handler for processing CompleteToDoItemCommand.
  /// Handler para processar o comando de conclusão.
  /// </summary>
  public class CompleteToDoItemHandler : IRequestHandler<CompleteToDoItemCommand, Result>
  {
    private readonly IToDoRepository _repository;
    private readonly INotifier _notifier;

    public CompleteToDoItemHandler(IToDoRepository repository, INotifier notifier)
    {
      _repository = repository;
      _notifier = notifier;
    }

    public async Task<Result> Handle(CompleteToDoItemCommand request, CancellationToken cancellationToken)
    {
      var item = await _repository.GetByIdAsync(request.Id);
      if (item == null)
      {
        return Result.Fail("Item not found / Item não encontrado");
      }

      item.MarkAsDone();
      await _repository.UpdateAsync(item);

      // Notify via SignalR
      // Notifica via SignalR
      await _notifier.NotifyAsync($"Task '{item.Title}' completed!");

      return Result.Ok();
    }
  }
}

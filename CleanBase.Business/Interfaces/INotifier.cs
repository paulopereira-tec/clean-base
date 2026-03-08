namespace CleanBase.Business.Interfaces
{
  /// <summary>
  /// Interface for notifying clients (e.g. via SignalR).
  /// Interface para notificar clientes (ex: via SignalR).
  /// </summary>
  public interface INotifier
  {
    Task NotifyAsync(string message);
  }
}

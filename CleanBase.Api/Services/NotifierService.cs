using CleanBase.Api.Hubs;
using CleanBase.Business.Interfaces;
using Microsoft.AspNetCore.SignalR;

namespace CleanBase.Api.Services
{
  /// <summary>
  /// Concrete implementation of INotifier using SignalR.
  /// Implementação concreta de INotifier usando SignalR.
  /// </summary>
  public class NotifierService : INotifier
  {
    private readonly IHubContext<NotificationHub> _hubContext;

    public NotifierService(IHubContext<NotificationHub> hubContext)
    {
      _hubContext = hubContext;
    }

    public async Task NotifyAsync(string message)
    {
      // Send message to all connected clients
      // Envia mensagem para todos os clientes conectados
      await _hubContext.Clients.All.SendAsync("ReceiveMessage", message);
    }
  }
}

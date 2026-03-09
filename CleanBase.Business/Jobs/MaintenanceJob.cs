using CleanBase.Domain.Interfaces;
using Microsoft.Extensions.Logging;

namespace CleanBase.Business.Jobs
{
  /// <summary>
  /// Example of a background job to be executed by Hangfire.
  /// Exemplo de um job em segundo plano para ser executado pelo Hangfire.
  /// </summary>
  public class MaintenanceJob
  {
    private readonly IToDoRepository _toDoRepository;
    private readonly ILogger<MaintenanceJob> _logger;

    public MaintenanceJob(IToDoRepository toDoRepository, ILogger<MaintenanceJob> logger)
    {
      _toDoRepository = toDoRepository;
      _logger = logger;
    }

    public async Task Execute()
    {
      _logger.LogInformation("Maintenance Job started.");

      var items = await _toDoRepository.GetAllAsync(CancellationToken.None);

      Console.WriteLine($"[" + DateTime.Now + $"] Maintenance job executed! Found {items.Count} items. / Job de manutenção executado! Encontrado {items.Count} itens.");

      _logger.LogInformation("Maintenance Job finished.");
    }
  }
}

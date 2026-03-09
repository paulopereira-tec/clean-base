using CleanBase.Domain.Entities.Reports;
using CleanBase.Domain.Interfaces.Reports;
using CleanBase.Infrastructure.Data;

namespace CleanBase.Repository.Repositories.Reports;

internal class ConnectorRepository : Repository<Connector>, IConnectorRepository
{
  public ConnectorRepository(ApplicationDbContext context) : base(context)
  {
  }
}

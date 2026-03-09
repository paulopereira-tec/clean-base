using CleanBase.Domain.Entities;
using CleanBase.Shared;
using MediatR;

namespace CleanBase.Business.Features.Reports.Connectors.GetAllConnectors;

public class GetAllConnectorsQueryHandler : IRequestHandler<GetAllConnectorsQuery, Result<List<GetAllConnectorsResponse>>>
{
  public Task<Result<List<GetAllConnectorsResponse>>> Handle(GetAllConnectorsQuery request, CancellationToken cancellationToken)
  {
    throw new NotImplementedException();
  }
}

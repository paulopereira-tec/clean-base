using CleanBase.Shared;
using MediatR;

namespace CleanBase.Business.Features.Reports.Connectors.GetAllConnectors;

public class GetAllConnectorsQuery : IRequest<Result<List<GetAllConnectorsResponse>>>
{
}

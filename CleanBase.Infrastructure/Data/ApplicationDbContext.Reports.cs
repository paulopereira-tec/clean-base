using CleanBase.Domain.Entities.Reports;
using Microsoft.EntityFrameworkCore;

namespace CleanBase.Infrastructure.Data;

public partial class ApplicationDbContext
{
  public DbSet<Connector> Connectors { get; set; }
}

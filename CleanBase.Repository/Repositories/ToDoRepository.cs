using CleanBase.Domain.Entities;
using CleanBase.Domain.Interfaces;
using CleanBase.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace CleanBase.Repository.Repositories;

/// <summary>
/// Implementation of IToDoRepository using EF Core.
/// Implementação de IToDoRepository usando EF Core.
/// </summary>
public class ToDoRepository : Repository<ToDoItem>, IToDoRepository
{
  private readonly ApplicationDbContext _context;

  public ToDoRepository(ApplicationDbContext context): base(context)
  {
    _context = context;
  }

  public async Task<List<ToDoItem>> GetAllAsync(CancellationToken cancellationToken)
  {
    return await _context.ToDoItems.ToListAsync(cancellationToken);
  }

}

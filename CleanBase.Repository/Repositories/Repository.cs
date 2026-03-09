using CleanBase.Domain.Interfaces;
using CleanBase.Infrastructure.Data;
using CleanBase.Shared;
using Microsoft.EntityFrameworkCore;

namespace CleanBase.Repository.Repositories;

public abstract class Repository<T> : IRepository<T> where T : Entity
{
  private readonly ApplicationDbContext _context;

  public Repository(ApplicationDbContext context)
  {
    _context = context;
  }

  public async Task AddAsync(T entity, CancellationToken cancellationToken)
  {
    await _context.Set<T>().AddAsync(entity, cancellationToken);
    await _context.SaveChangesAsync();
  }

  public virtual async Task<bool> DeleteAsync(T entity, CancellationToken cancellationToken)
  {
    _context.Set<T>().Remove(entity);
    int totalDeleted = await _context.SaveChangesAsync(cancellationToken);
    return totalDeleted > 0;
  }

  public virtual async Task<T?> GetByIdAsync(Guid id, CancellationToken cancellationToken)
  {
    T? result = await _context
        .Set<T>()
        .FirstOrDefaultAsync(x => x.Id == id);

    return result;
  }

  public virtual async Task<T> UpdateAsync(T entity, CancellationToken cancellationToken)
  {
    _context.Set<T>().Update(entity);
    await _context.SaveChangesAsync();
    return entity;
  }
}

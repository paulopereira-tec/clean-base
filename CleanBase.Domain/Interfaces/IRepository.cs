namespace CleanBase.Domain.Interfaces;

public interface IRepository<T>
{
  Task<T?> GetByIdAsync(Guid id, CancellationToken cancellationToken);
  Task AddAsync(T entity, CancellationToken cancellationToken);
  Task<T> UpdateAsync(T entity, CancellationToken cancellationToken);
  Task<bool> DeleteAsync(T entity, CancellationToken cancellationToken);
}

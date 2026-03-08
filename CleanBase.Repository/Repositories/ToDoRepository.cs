using CleanBase.Domain.Entities;
using CleanBase.Domain.Interfaces;
using CleanBase.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace CleanBase.Repository.Repositories
{
  /// <summary>
  /// Implementation of IToDoRepository using EF Core.
  /// Implementação de IToDoRepository usando EF Core.
  /// </summary>
  public class ToDoRepository : IToDoRepository
  {
    private readonly ApplicationDbContext _context;

    public ToDoRepository(ApplicationDbContext context)
    {
      _context = context;
    }

    public async Task AddAsync(ToDoItem item)
    {
      await _context.ToDoItems.AddAsync(item);
      await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(Guid id)
    {
      var item = await _context.ToDoItems.FindAsync(id);
      if (item != null)
      {
        _context.ToDoItems.Remove(item);
        await _context.SaveChangesAsync();
      }
    }

    public async Task<List<ToDoItem>> GetAllAsync()
    {
      return await _context.ToDoItems.ToListAsync();
    }

    public async Task<ToDoItem?> GetByIdAsync(Guid id)
    {
      return await _context.ToDoItems.FindAsync(id);
    }

    public async Task UpdateAsync(ToDoItem item)
    {
      _context.ToDoItems.Update(item);
      await _context.SaveChangesAsync();
    }
  }
}

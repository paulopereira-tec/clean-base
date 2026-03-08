using CleanBase.Domain.Entities;
using CleanBase.Shared;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace CleanBase.Infrastructure.Data
{
  /// <summary>
  /// Database context for the application.
  /// Contexto de banco de dados da aplicação.
  /// </summary>
  public class ApplicationDbContext : DbContext
  {
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
    }

    public DbSet<ToDoItem> ToDoItems { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
      base.OnModelCreating(modelBuilder);

      // Apply configurations from assembly
      // Aplica as configurações do assembly atual
      modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

      // Apply Global Query Filter for Soft Delete
      // Aplica filtro global para exclusão lógica
      foreach (var entityType in modelBuilder.Model.GetEntityTypes())
      {
        if (typeof(Entity).IsAssignableFrom(entityType.ClrType))
        {
          var parameter = System.Linq.Expressions.Expression.Parameter(entityType.ClrType, "p");
          var deletedAtProperty = System.Linq.Expressions.Expression.Property(parameter, "DeletedAt");
          var nullExpression = System.Linq.Expressions.Expression.Constant(null);
          var filter = System.Linq.Expressions.Expression.Lambda(
              System.Linq.Expressions.Expression.Equal(deletedAtProperty, nullExpression),
              parameter);
          modelBuilder.Entity(entityType.ClrType).HasQueryFilter(filter);
        }
      }
    }

    public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
      foreach (var entry in ChangeTracker.Entries<Entity>())
      {
        switch (entry.State)
        {
          case EntityState.Added:
            entry.Entity.CreatedAt = DateTime.UtcNow;
            entry.Entity.UpdatedAt = null;
            entry.Entity.DeletedAt = null;
            break;

          case EntityState.Modified:
            entry.Entity.UpdatedAt = DateTime.UtcNow;
            break;

          case EntityState.Deleted:
            entry.State = EntityState.Modified;
            entry.Entity.DeletedAt = DateTime.UtcNow;
            entry.Entity.UpdatedAt = DateTime.UtcNow;
            break;
        }
      }

      return base.SaveChangesAsync(cancellationToken);
    }
  }
}

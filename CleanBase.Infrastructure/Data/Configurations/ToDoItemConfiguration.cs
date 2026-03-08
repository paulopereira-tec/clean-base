using CleanBase.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CleanBase.Infrastructure.Data.Configurations
{
  /// <summary>
  /// Configuration for ToDoItem entity mapping.
  /// Configuração do mapeamento da entidade ToDoItem.
  /// </summary>
  public class ToDoItemConfiguration : IEntityTypeConfiguration<ToDoItem>
  {
    public void Configure(EntityTypeBuilder<ToDoItem> builder)
    {
      builder.ToTable("ToDoItems");

      builder.HasKey(x => x.Id);

      builder.Property(x => x.Title)
          .IsRequired()
          .HasMaxLength(100);

      builder.Property(x => x.Description)
          .HasMaxLength(500);

      builder.Property(x => x.Status)
          .IsRequired();
    }
  }
}

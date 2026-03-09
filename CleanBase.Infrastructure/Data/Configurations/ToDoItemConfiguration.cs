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
      builder.ToTable(nameof(ToDoItem).ToUpper());

      builder.HasKey(x => x.Id);

      builder
        .Property(x => x.Title)
        .HasColumnName(nameof(ToDoItem.Title).ToUpper())
        .IsRequired()
        .HasMaxLength(100);

      builder
        .Property(x => x.Description)
        .HasColumnName(nameof(ToDoItem.Description).ToUpper())
        .HasMaxLength(500);

      builder
        .Property(x => x.Status)
        .HasColumnName(nameof(ToDoItem.Status).ToUpper())
        .IsRequired();
    }
  }
}

namespace CleanBase.Shared
{
  /// <summary>
  /// Base class for all entities.
  /// Classe base para todas as entidades.
  /// </summary>
  public abstract class Entity
  {
    /// <summary>
    /// Unique identifier for the entity.
    /// Identificador único da entidade.
    /// </summary>
    public Guid Id { get; protected set; }

    /// <summary>
    /// Dto creation of the entity.
    /// Data de criação da entidade.
    /// </summary>
    /// <summary>
    /// Date of creation of the entity.
    /// Data de criação da entidade.
    /// </summary>
    public DateTime CreatedAt { get; set; }

    /// <summary>
    /// Date of last update.
    /// Data da última atualização.
    /// </summary>
    public DateTime? UpdatedAt { get; set; }

    /// <summary>
    /// Date of soft deletion.
    /// Data da exclusão lógica.
    /// </summary>
    public DateTime? DeletedAt { get; set; }

    protected Entity()
    {
      Id = Guid.NewGuid();
      CreatedAt = DateTime.UtcNow;
    }
  }
}

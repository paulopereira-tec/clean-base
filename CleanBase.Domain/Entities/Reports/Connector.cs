using CleanBase.Domain.Enums.Reports;
using CleanBase.Shared;

namespace CleanBase.Domain.Entities.Reports;

/// <summary>
/// Entidade responsável por criar conexões com fontes de dados externas, como bancos de dados, APIs, etc.
/// </summary>
public class Connector: Entity
{
  /// <summary>
  /// Nome da conexão associada a este conector, utilizado para identificar a fonte de dados externa.
  /// </summary>
  public string Name { get; set; }

  /// <summary>
  /// Tipo de conexão. Define o tipo de fonte de dados externa, como SQL Server, MySQL, API REST,
  /// etc., permitindo que o sistema saiba como se conectar e interagir com a fonte de dados específica.
  /// </summary>
  public EConnectorType ConnectorType { get; set; }

  /// <summary>
  /// Configuração usada para realizar a conexão com o banco de dados, API ou outra fonte de dados externa.
  /// </summary>
  /// <remarks>
  /// Contém as informações necessárias para estabelecer a conexão, como endereço do servidor, nome do
  /// banco de dados, credenciais de acesso, etc., dependendo do tipo de conexão especificado. A configuração
  /// será armazenada em JSON.
  /// </remarks>
  public string Configuration { get; set; }
}

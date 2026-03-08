namespace CleanBase.Shared
{
  /// <summary>
  /// Represents the result of an operation.
  /// Representa o resultado de uma operação.
  /// </summary>
  /// <typeparam name="T">Type of the data returned. Tipo do dado retornado.</typeparam>
  public class Result<T>
  {
    /// <summary>
    /// Indicates if the operation was successful.
    /// Indica se a operação foi bem sucedida.
    /// </summary>
    public bool Success { get; private set; }

    /// <summary>
    /// The data returned by the operation.
    /// O dado retornado pela operação.
    /// </summary>
    public T Data { get; private set; }

    /// <summary>
    /// List of error messages if the operation failed.
    /// Lista de mensagens de erro se a operação falhou.
    /// </summary>
    public List<string> Errors { get; private set; }

    private Result(bool success, T data, List<string> errors)
    {
      Success = success;
      Data = data;
      Errors = errors;
    }

    public static Result<T> Ok(T data)
    {
      return new Result<T>(true, data, new List<string>());
    }

    public static Result<T> Fail(string error)
    {
      return new Result<T>(false, default, new List<string> { error });
    }

    public static Result<T> Fail(List<string> errors)
    {
      return new Result<T>(false, default, errors);
    }
  }

  /// <summary>
  /// Represents the result of an operation without data.
  /// Representa o resultado de uma operação sem dados.
  /// </summary>
  public class Result
  {
    public bool Success { get; private set; }
    public List<string> Errors { get; private set; }

    private Result(bool success, List<string> errors)
    {
      Success = success;
      Errors = errors;
    }

    public static Result Ok()
    {
      return new Result(true, new List<string>());
    }

    public static Result Fail(string error)
    {
      return new Result(false, new List<string> { error });
    }

    public static Result Fail(List<string> errors)
    {
      return new Result(false, errors);
    }
  }
}

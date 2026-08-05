namespace Articles.Domain.Common.Exceptions;

/// <summary>
///     Исключение "Объект не найден"
/// </summary>
public sealed class EntityNotFoundException : Exception
{
    public EntityNotFoundException()
    {
    }

    public EntityNotFoundException(string message)
        : base(message)
    {
    }

    public EntityNotFoundException(string message,
        Exception innerException)
        : base(message, innerException)
    {
    }
}
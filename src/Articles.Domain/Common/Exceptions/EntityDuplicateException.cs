namespace Articles.Domain.Common.Exceptions;

/// <summary>
///     Исключение "Повторяющийся объект"
/// </summary>
public sealed class EntityDuplicateException : Exception
{
    public EntityDuplicateException()
    {
    }

    public EntityDuplicateException(string message)
        : base(message)
    {
    }

    public EntityDuplicateException(string message,
        Exception innerException)
        : base(message, innerException)
    {
    }
}
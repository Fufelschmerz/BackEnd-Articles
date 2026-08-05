namespace Articles.Domain.Common.Exceptions;

/// <summary>
///     Исключение о различных ошибках валидаций
/// </summary>
public sealed class ValidationException : Exception
{
    public ValidationException()
    {
    }

    public ValidationException(string message)
        : base(message)
    {
    }

    public ValidationException(string message,
        Exception innerException)
        : base(message, innerException)
    {
    }
}
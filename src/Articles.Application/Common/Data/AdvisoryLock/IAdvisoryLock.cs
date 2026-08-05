namespace Articles.Application.Common.Data.AdvisoryLock;

public interface IAdvisoryLock
{
    /// <summary>
    ///     Захватить блокировку
    /// </summary>
    /// <remarks>
    ///     Захватывает блокировку в рамках текущей транзакции.
    ///     Метод должен вызываться в контексте транзакции <see cref="ITransaction" />
    /// </remarks>
    Task LockAsync();
}
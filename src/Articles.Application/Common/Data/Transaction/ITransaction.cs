namespace Articles.Application.Common.Data.Transaction;

/// <summary>
///     Интерфейс транзакции БД
/// </summary>
public interface ITransaction : IDisposable
{
    /// <summary>
    ///     Зафиксировать изменения
    /// </summary>
    Task CommitAsync();

    /// <summary>
    ///     Откатить изменения
    /// </summary>
    Task RollbackAsync();
}
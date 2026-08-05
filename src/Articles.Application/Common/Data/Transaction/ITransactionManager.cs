using System.Data;

namespace Articles.Application.Common.Data.Transaction;

/// <summary>
///     Интерфейс менеджера транзакций
/// </summary>
public interface ITransactionManager
{
    /// <summary>
    ///     Начать новую транзакцию
    /// </summary>
    /// <returns>Созданная транзакция</returns>
    Task<ITransaction> BeginTransactionAsync(IsolationLevel isolationLevel = IsolationLevel.ReadCommitted);
}
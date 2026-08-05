using Articles.Application.Common.Data.Transaction;
using Microsoft.EntityFrameworkCore.Storage;

namespace Articles.Infrastructure.Data.Transaction;

internal sealed class Transaction : ITransaction
{
    private readonly IDbContextTransaction _transaction;

    public Transaction(IDbContextTransaction transaction)
    {
        _transaction = transaction;
    }

    public async Task CommitAsync()
    {
        await _transaction.CommitAsync();
    }

    public async Task RollbackAsync()
    {
        await _transaction.RollbackAsync();
    }

    public void Dispose()
    {
        _transaction.Dispose();
    }
}
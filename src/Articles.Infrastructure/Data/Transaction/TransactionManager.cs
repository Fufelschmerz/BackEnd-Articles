using Articles.Application.Common.Data.Transaction;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace Articles.Infrastructure.Data.Transaction;

internal sealed class TransactionManager(AppDbContext dbContext) : ITransactionManager
{
    public async Task<ITransaction> BeginTransactionAsync(IsolationLevel isolationLevel = IsolationLevel.ReadCommitted)
    {
        var transaction = await dbContext.Database.BeginTransactionAsync(isolationLevel);
        return new Transaction(transaction);
    }
}
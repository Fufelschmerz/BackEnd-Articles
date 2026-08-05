using Articles.Application.Common.Data.AdvisoryLock;
using Microsoft.EntityFrameworkCore;

namespace Articles.Infrastructure.Data.AdvisoryLock;

internal sealed class AdvisoryLock : IAdvisoryLock
{
    private readonly AppDbContext _dbContext;
    private readonly long _id;

    public AdvisoryLock(AppDbContext dbContext,
        long id)
    {
        _dbContext = dbContext;
        _id = id;
    }

    public async Task LockAsync()
    {
        await _dbContext.Database.ExecuteSqlInterpolatedAsync($"SELECT pg_advisory_xact_lock({_id});");
    }
}
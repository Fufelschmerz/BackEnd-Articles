using Microsoft.EntityFrameworkCore;

namespace Articles.Infrastructure.Data.Pagination.Extensions;

internal static class QueryableExtensions
{
    public static async Task<Page<T>> ToPageAsync<T>(this IQueryable<T> query,
        int pageSize,
        int pageNumber,
        CancellationToken cancellationToken = default)
    {
        var total = await query.CountAsync(cancellationToken);
        var items = await query
            .Skip(pageSize * pageNumber)
            .Take(pageSize)
            .ToListAsync(cancellationToken);

        return new Page<T>(pageNumber, pageSize, total, items);
    }
}
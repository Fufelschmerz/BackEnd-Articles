namespace Articles.Infrastructure.Data.Pagination;

internal sealed record Page<T>(int Number,
    int Size,
    long Total,
    IReadOnlyList<T> Items);
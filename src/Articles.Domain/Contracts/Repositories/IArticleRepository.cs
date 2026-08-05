using Articles.Domain.Entities;

namespace Articles.Domain.Contracts.Repositories;

/// <summary>
///     Интерфейс репозитория для статей
/// </summary>
public interface IArticleRepository
{
    Task<Guid> CreateAsync(Article article,
        CancellationToken cancellationToken = default);

    Task UpdateAsync(Article article,
        CancellationToken cancellationToken = default);

    Task<int> DeleteAsync(Guid id,
        CancellationToken cancellationToken = default);

    Task<Article?> GetOrDefaultByIdAsync(Guid id,
        CancellationToken cancellationToken = default);
}
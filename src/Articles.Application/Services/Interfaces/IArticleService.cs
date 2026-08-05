using Articles.Domain.Entities;

namespace Articles.Application.Services.Interfaces;

/// <summary>
///     Сервис для работы со статьями
/// </summary>
public interface IArticleService
{
    /// <summary>
    ///     Создать статью
    /// </summary>
    /// <param name="name">Название</param>
    /// <param name="tagIds">Список тэгов</param>
    /// <param name="cancellationToken"></param>
    /// <returns>Идентификатор созданного объекта</returns>
    Task<Guid> CreateAsync(string name,
        IReadOnlyList<Guid> tagIds,
        CancellationToken cancellationToken = default);

    /// <summary>
    ///     Обновить статью
    /// </summary>
    /// <param name="id">Идентификатор</param>
    /// <param name="name">Название статьи</param>
    /// <param name="tagIds">Список тэгов</param>
    /// <param name="cancellationToken"></param>
    Task UpdateAsync(Guid id,
        string name,
        IReadOnlyList<Guid> tagIds,
        CancellationToken cancellationToken = default);

    /// <summary>
    ///     Удалить статью
    /// </summary>
    /// <param name="id">Идентификатор статьи</param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    Task<int> DeleteAsync(Guid id,
        CancellationToken cancellationToken = default);

    /// <summary>
    ///     Получить статью по идентификатору
    /// </summary>
    /// <param name="id">Идентификатор</param>
    /// <param name="cancellationToken"></param>
    /// <returns>Статья</returns>
    Task<Article> GetByIdAsync(Guid id,
        CancellationToken cancellationToken = default);
}
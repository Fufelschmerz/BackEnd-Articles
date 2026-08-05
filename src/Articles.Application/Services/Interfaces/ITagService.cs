using Articles.Domain.Entities;

namespace Articles.Application.Services.Interfaces;

/// <summary>
///     Сервис работы с тэгами
/// </summary>
public interface ITagService
{
    /// <summary>
    ///     Создать тэг
    /// </summary>
    /// <param name="name">Название тэга</param>
    /// <param name="cancellationToken"></param>
    /// <returns>Идентификатор созданного объекта</returns>
    Task<Guid> CreateAsync(string name,
        CancellationToken cancellationToken = default);

    /// <summary>
    ///     Получить список тэгов
    /// </summary>
    /// <param name="name">Название искомого тэга</param>
    /// <param name="count">Количество тэгов</param>
    /// <param name="cancellationToken"></param>
    /// <returns>Список тэгов</returns>
    Task<IReadOnlyList<Tag>> GetListAsync(string name,
        int count,
        CancellationToken cancellationToken = default);
}
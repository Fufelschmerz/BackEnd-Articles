namespace Articles.Core.Models;

/// <summary>
///     Статья
/// </summary>
/// <param name="Id">Идентификатор</param>
/// <param name="Name">Название</param>
/// <param name="CreatedAt">Дата создания</param>
/// <param name="ModifyAt">Дата обновления</param>
/// <param name="Tags">Набор тэгов</param>
public sealed record ArticleModel(Guid Id,
    string Name,
    DateTime CreatedAt,
    DateTime? ModifyAt,
    IReadOnlyList<TagModel> Tags);
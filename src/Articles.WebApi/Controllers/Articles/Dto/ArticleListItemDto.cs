namespace Articles.WebApi.Controllers.Articles.Dto;

/// <summary>
///     Элемент списка статей
/// </summary>
/// <param name="Id">Id статьи</param>
/// <param name="Name">Название статьи</param>
/// <param name="CreatedAt">Дата создания</param>
/// <param name="ModifyAt">Дата обновления</param>
public sealed record ArticleListItemDto(Guid Id,
    string Name,
    DateTime CreatedAt,
    DateTime? ModifyAt);
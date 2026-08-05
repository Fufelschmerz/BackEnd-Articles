namespace Articles.WebApi.Controllers.CatalogArticles.Dto;

/// <summary>
///     Элемент списка разделов
/// </summary>
/// <param name="Id">Id раздела</param>
/// <param name="Name">Название раздела</param>
/// <param name="ArticleCount">Количество статей</param>
public sealed record SectionListItemDto(Guid Id,
    string Name,
    int ArticleCount);
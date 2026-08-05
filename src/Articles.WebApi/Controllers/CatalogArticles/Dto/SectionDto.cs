using Articles.WebApi.Controllers.Articles.Dto;
using Articles.WebApi.Controllers.Tags.Dto;

namespace Articles.WebApi.Controllers.CatalogArticles.Dto;

/// <summary>
///     Раздел
/// </summary>
/// <param name="Id">Id раздела</param>
/// <param name="Name">Название раздела</param>
/// <param name="Articles">Список статей</param>
/// <param name="Tags">Список тэгов</param>
public sealed record SectionDto(Guid Id,
    string Name,
    IEnumerable<ArticleListItemDto> Articles,
    IEnumerable<TagDto> Tags);
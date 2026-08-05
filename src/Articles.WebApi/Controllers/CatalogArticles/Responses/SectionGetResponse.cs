using Articles.WebApi.Controllers.CatalogArticles.Dto;

namespace Articles.WebApi.Controllers.CatalogArticles.Responses;

/// <summary>
///     Ответ на получение раздела
/// </summary>
/// <param name="Section">Раздел</param>
public sealed record SectionGetResponse(SectionDto Section);
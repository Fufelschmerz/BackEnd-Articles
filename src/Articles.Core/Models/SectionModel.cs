namespace Articles.Core.Models;

/// <summary>
///     Раздел
/// </summary>
/// <param name="Id">Идентификатор</param>
/// <param name="Name">Название</param>
/// <param name="Tags">Список тэгов</param>
/// <param name="Articles">Список статей</param>
public sealed record SectionModel(Guid Id,
    string Name,
    IReadOnlyList<TagModel> Tags,
    IReadOnlyList<ArticleModel> Articles)
{
    /// <summary>
    ///     Максимальное число тэгов
    /// </summary>
    public const int MaxTags = 256;

    /// <summary>
    ///     Максимальная длина имени
    /// </summary>
    public const int MaxLengthName = 1024;

    /// <summary>
    ///     Кол-во статей
    /// </summary>
    public int ArticleCount => Articles.Count;
}
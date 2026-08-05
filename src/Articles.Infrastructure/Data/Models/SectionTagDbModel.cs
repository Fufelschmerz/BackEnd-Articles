namespace Articles.Infrastructure.Data.Models;

public sealed class SectionTagDbModel
{
    public Guid SectionId { get; set; }

    public Guid TagId { get; set; }

    public int SortNumber { get; set; }

    public SectionDbModel? Section { get; set; }

    public TagDbModel? Tag { get; set; }
}
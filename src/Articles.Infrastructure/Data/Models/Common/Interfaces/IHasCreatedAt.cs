namespace Articles.Infrastructure.Data.Models.Common.Interfaces;

internal interface IHasCreatedAt
{
    DateTime CreatedAt { get; set; }
}
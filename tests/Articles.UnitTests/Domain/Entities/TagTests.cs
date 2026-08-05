using Articles.Domain.Entities;
using Xunit;

namespace Articles.UnitTests.Domain.Entities;

public sealed class TagTests
{
    [Theory]
    [InlineData("ЭПИДЕМИЯ", "эпидемия")]
    [InlineData("эп и де   ми я", "эпидемия")]
    [InlineData("   эпидемия   ", "эпидемия")]
    [InlineData("", "")]
    [InlineData("     ", "")]
    [InlineData("  Эпи ДЕ ми Я ", "эпидемия")]
    public void NormalizeName_Returns_NormalizedValue(string input,
        string expected)
    {
        // act
        var tag = new Tag
        {
            Name = input
        };

        // assert
        Assert.Equal(expected, tag.NormalizedName);
    }
}
using Articles.Domain.Entities;
using Xunit;

namespace Articles.UnitTests.Domain.Entities;

public sealed class SectionTests
{
    [Theory]
    [MemberData(nameof(BuildTags))]
    public void BuildName_Returns_ConcatenatedTagNames(IReadOnlyList<Tag> tags,
        string expectedName)
    {
        // act
        var section = new Section(tags);

        // assert
        Assert.Equal(expectedName, section.Name);
    }

    [Fact]
    public void BuildName_ThrowsValidationException_WhenResultIsEmpty()
    {
        // act
        Section Result() => new([]);

        //assert
        Assert.Throws<ArgumentException>(Result);
    }

    public static IEnumerable<object[]> BuildTags()
    {
        yield return new object[]
        {
            new List<Tag>
            {
                new()
                {
                    Name = "test"
                }
            },
            "test"
        };

        yield return new object[]
        {
            new List<Tag>
            {
                new()
                {
                    Name = "test"
                },
                new()
                {
                    Name = "abc"
                }
            },
            "test,abc"
        };

        yield return new object[]
        {
            new List<Tag>
            {
                new()
                {
                    Name = "1234567890"
                },
                new()
                {
                    Name = "1234567890"
                },
                new()
                {
                    Name = new string('X', Section.MAX_LENGTH_NAME)
                }
            },
            "1234567890,1234567890"
        };
    }
}
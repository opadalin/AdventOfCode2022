using AdventOfCode.Day3;
using AdventOfCode.Tests.Helpers;
using Xunit;
using Xunit.Abstractions;

namespace AdventOfCode.Tests.Day3;

public class RucksackReorganizationServiceTests
{
    private readonly ITestOutputHelper _outputHelper;

    public RucksackReorganizationServiceTests(ITestOutputHelper outputHelper)
    {
        _outputHelper = outputHelper;
    }

    [Theory(DisplayName = "Get sum of priorities")]
    [InlineData("rucksack.txt", 8240, true)]
    [InlineData("azcdkAZCDk", 11, false)]
    [InlineData("vJrwpWtwJgWrhcsFMMfFFhFp\n" +
                "jqHRNqRjqzjGDLGLrsFMfFZSrLrFZsSL\n" +
                "PmmdzqPrVvPwwTWBwg\n" +
                "wMqvLMZHhHMvwLHjbvcjnnSBnvTQFn\n" +
                "ttgJtRGJQctTZtZT\n" +
                "CrZsJsPPZsGzwwsLwLmpwMDw", 157, false)]
    public void CanCalculateTotalScore(string inputData, int expected, bool readFromFile)
    {
        // given
        var data = readFromFile ? FileReader.ReadResource(inputData) : inputData;

        var sut = new RucksackReorganizationService(data);

        // when
        var actual = sut.GetPriorityScore();

        // then
        Assert.Equal(expected, actual);
        _outputHelper.WriteLine($"Total priority score is {actual}");
    }

    [Theory(DisplayName = "Get group badge priority score")]
    [InlineData("rucksack.txt", 2587, true)]
    [InlineData("vJrwpWtwJgWrhcsFMMfFFhFp\n" +
                "jqHRNqRjqzjGDLGLrsFMfFZSrLrFZsSL\n" +
                "PmmdzqPrVvPwwTWBwg\n" +
                "wMqvLMZHhHMvwLHjbvcjnnSBnvTQFn\n" +
                "ttgJtRGJQctTZtZT\n" +
                "CrZsJsPPZsGzwwsLwLmpwMDw", 70, false)]
    public void CanGetGroupBadePriorityScore(string inputData, int expected, bool readFromFile)
    {
        // given
        var data = readFromFile ? FileReader.ReadResource(inputData) : inputData;

        var sut = new RucksackReorganizationService(data);

        // when
        var actual = sut.GetGroupBadgePriorityScore();

        // then
        Assert.Equal(expected, actual);
        _outputHelper.WriteLine($"Total priority score is {actual}");
    }
}
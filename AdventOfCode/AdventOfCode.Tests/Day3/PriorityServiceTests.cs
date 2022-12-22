using AdventOfCode.Day3;
using AdventOfCode.Tests.Helpers;
using Xunit;
using Xunit.Abstractions;

namespace AdventOfCode.Tests.Day3;

public class PriorityServiceTests
{
    private readonly ITestOutputHelper _outputHelper;

    public PriorityServiceTests(ITestOutputHelper outputHelper)
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

        var sut = new PriorityService(data);

        // when
        var priorityScore = sut.GetPriorityScore();

        // then
        Assert.Equal(expected, priorityScore);
        _outputHelper.WriteLine($"Total priority score is {priorityScore}");
    }
}
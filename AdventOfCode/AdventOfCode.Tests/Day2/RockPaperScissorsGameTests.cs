using AdventOfCode.Day2;
using AdventOfCode.Tests.Helpers;
using Xunit;
using Xunit.Abstractions;

namespace AdventOfCode.Tests.Day2;

public class RockPaperScissorsGameTests
{
    private readonly ITestOutputHelper _outputHelper;

    public RockPaperScissorsGameTests(ITestOutputHelper outputHelper)
    {
        _outputHelper = outputHelper;
    }

    [Theory(DisplayName = "Calculate total score")]
    [InlineData("RPS-strategy-guide.txt", 12679, true)]
    [InlineData("A Y\nB X\nC Z", 15, false)]
    public void CanCalculateTotalScore(string inputData, int expected, bool readFromFile)
    {
        // given
        var data = readFromFile ? FileReader.ReadResource(inputData) : inputData;

        var sut = new RockPaperScissorsGame(data, new WinningStrategy());

        // when
        var score = sut.Play();

        // then
        Assert.Equal(expected, score);
        _outputHelper.WriteLine($"My total score is {score}");
    }

    [Theory(DisplayName = "Calculate total score example input part 2")]
    [InlineData("RPS-strategy-guide.txt", 14777, true)]
    [InlineData("A Y\nB X\nC Z", 12, false)]
    public void CanCalculateTotalScoreExampleInputPart2(string inputData, int expected, bool readFromFile)
    {
        // given
        var data = readFromFile ? FileReader.ReadResource(inputData) : inputData;
        var sut = new RockPaperScissorsGame(data, new FollowInstructionsStrategy());

        // when
        var score = sut.Play();

        // then
        Assert.Equal(expected, score);
        _outputHelper.WriteLine($"My total score is {score}");
    }
}
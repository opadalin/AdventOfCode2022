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

    [Theory(DisplayName = "Calculate total score using winning strategy")]
    [InlineData("RPS-strategy-guide.txt", 12679, true)]
    [InlineData("A Y\nB X\nC Z", 15, false)]
    public void CanCalculateTotalScore(string inputData, int expected, bool readFromFile)
    {
        // given
        var data = readFromFile ? FileReader.ReadResource(inputData) : inputData;

        var sut = new RockPaperScissorsGame(data, new Part1Strategy());

        // when
        var score = sut.Play();

        // then
        Assert.Equal(expected, score);
        _outputHelper.WriteLine($"My total score is {score}");
    }

    [Theory(DisplayName = "Calculate total score following instructions strategy")]
    [InlineData("RPS-strategy-guide.txt", 14470, true)]
    [InlineData("A Y\nB X\nC Z", 12, false)]
    [InlineData("A Y\nB X\nC Z\nA Y\nB X\nC Z", 24, false)]
    public void CanCalculateTotalScoreExampleInputPart2(string inputData, int expected, bool readFromFile)
    {
        // given
        var data = readFromFile ? FileReader.ReadResource(inputData) : inputData;
        var sut = new RockPaperScissorsGame(data, new Part2Strategy());

        // when
        var score = sut.Play();

        // then
        Assert.Equal(expected, score);
        _outputHelper.WriteLine($"My total score is {score}");
    }
}
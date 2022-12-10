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
    [InlineData("RPS-strategy-guide.txt", 12679)]
    public void CanCalculateTotalScore(string dataset, int expected)
    {
        // given
        var data = FileReader.ReadResource(dataset);
        var sut = new RockPaperScissorsGame(data);
        
        // when
        var actual = sut.CalculateScoreForMe();

        // then
        Assert.Equal(expected, actual);
        _outputHelper.WriteLine($"My total score is {actual}");
    }
    
    [Theory(DisplayName = "Calculate total score")]
    [InlineData("A Y\nB X\nC Z", 15)]
    public void CanCalculateTotalScoreSimple(string data, int expected)
    {
        // given
        var sut = new RockPaperScissorsGame(data);
        
        // when
        var actual = sut.CalculateScoreForMe();

        // then
        Assert.Equal(expected, actual);
        _outputHelper.WriteLine($"My total score is {actual}");
    }
}
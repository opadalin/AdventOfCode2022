using AdventOfCode.Day6;
using AdventOfCode.Tests.Helpers;
using Xunit;
using Xunit.Abstractions;

namespace AdventOfCode.Tests.Day6;

public class TuningTroubleTests
{
    private readonly ITestOutputHelper _outputHelper;

    public TuningTroubleTests(ITestOutputHelper outputHelper)
    {
        _outputHelper = outputHelper;
    }

    [Theory(DisplayName = "Can calculate amount of characters before first start-of-packet is detected")]
    [InlineData("tuning-trouble.txt", 1855, true)]
    [InlineData("mjqjpqmgbljsphdztnvjfqwrcgsmlb", 7, false)]
    [InlineData("bvwbjplbgvbhsrlpgdmjqwftvncz", 5, false)]
    [InlineData("nppdvjthqldpwncqszvftbrmjlhg", 6, false)]
    [InlineData("nznrnfrfntjfmvfwmzdfjlvtqnbhcprsg", 10, false)]
    [InlineData("zcfzfwzzqfrljwzlrfnpqdbhtmscgvjw", 11, false)]
    public void CanCalculateAmountOfCharactersBeforeFirstStartOfPacketIsDetected(
        string inputData, int expected, bool readFromFile)
    {
        // given
        var data = readFromFile ? FileReader.ReadResource(inputData) : inputData;

        var sut = new TuningService(data);
        
        // when
        var actual = sut.DetectMarker(4);

        // then
        Assert.Equal(expected, actual);
        _outputHelper.WriteLine($"{actual}");
    }
    
    [Theory(DisplayName = "Can calculate amount of characters before first start-of-packet is detected")]
    [InlineData("tuning-trouble.txt", 3256, true)]
    [InlineData("mjqjpqmgbljsphdztnvjfqwrcgsmlb", 19, false)]
    [InlineData("bvwbjplbgvbhsrlpgdmjqwftvncz", 23, false)]
    [InlineData("nppdvjthqldpwncqszvftbrmjlhg", 23, false)]
    [InlineData("nznrnfrfntjfmvfwmzdfjlvtqnbhcprsg", 29, false)]
    [InlineData("zcfzfwzzqfrljwzlrfnpqdbhtmscgvjw", 26, false)]
    public void CanCalculateAmountOfCharactersBeforeFirstStartOfPacketIsDetectedForMessage(
        string inputData, int expected, bool readFromFile)
    {
        // given
        var data = readFromFile ? FileReader.ReadResource(inputData) : inputData;

        var sut = new TuningService(data);
        // when
        var actual = sut.DetectMarker(14);

        // then
        Assert.Equal(expected, actual);
        _outputHelper.WriteLine($"{actual}");
    }
}
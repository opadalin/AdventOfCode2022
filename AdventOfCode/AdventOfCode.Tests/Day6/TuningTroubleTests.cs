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

    [Theory(DisplayName = "Can")]
    [InlineData(".txt", "", true)]
    [InlineData(@"", "", false)]
    public void Can(string inputData, string expected, bool readFromFile)
    {
        // given
        var data = readFromFile ? FileReader.ReadResource(inputData) : inputData;

        // when
        var actual = expected;

        // then
        Assert.Equal(expected, actual);
        _outputHelper.WriteLine($"{actual}");
    }
}
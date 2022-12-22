using AdventOfCode.Day5;
using AdventOfCode.Tests.Helpers;
using Xunit;
using Xunit.Abstractions;

namespace AdventOfCode.Tests.Day5;

public class SupplyStacksTests
{
    private readonly ITestOutputHelper _outputHelper;

    public SupplyStacksTests(ITestOutputHelper outputHelper)
    {
        _outputHelper = outputHelper;
    }

    [Theory(DisplayName = "Get ")]
    [InlineData("supply-stacks.txt", "CMZ", true)]
    [InlineData("", "CMZ", false)]
    public void Test(string inputData, string expected, bool readFromFile)
    {
        // given
        var data = readFromFile ? FileReader.ReadResource(inputData) : inputData;

        var sut = new SupplyStacksService(data);

        // when
        var actual = sut.Bar();

        // then
        Assert.Equal(expected, actual);
        _outputHelper.WriteLine($"{actual}");
    }
}
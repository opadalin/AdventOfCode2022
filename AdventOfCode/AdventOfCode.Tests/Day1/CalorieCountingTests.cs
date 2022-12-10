using AdventOfCode.Day1;
using AdventOfCode.Tests.Helpers;
using Xunit;
using Xunit.Abstractions;

namespace AdventOfCode.Tests.Day1;

public class CalorieCountingTests
{
    private readonly ITestOutputHelper _outputHelper;

    public CalorieCountingTests(ITestOutputHelper outputHelper)
    {
        _outputHelper = outputHelper;
    }

    [Theory(DisplayName = "Can calculate and display the sum of the elf carrying most calories")]
    [InlineData("data.txt", 65912)]
    public void CanGetTheElfWithTheMostCalorieCount(string dataset, int expected)
    {
        // given
        var data = FileReader.ReadResource(dataset);
        var calorieCounting = new CalorieCounting(data);
        
        // when
        var actual = calorieCounting.GetCalorieCountForTheElfCarryingMost();
        
        // then
        Assert.Equal(expected, actual);
        _outputHelper.WriteLine($"The elf with the most calories has {actual} calories");
    }

    [Theory(DisplayName = "Can calculate and display the sum of the top three elves carrying most calories")]
    [InlineData("data.txt", 195625)]
    public void CanGetTheTopThreeElvesWithTheMostCalorieCount(string dataset, int expected)
    {
        // given
        var data = FileReader.ReadResource(dataset);
        var calorieCounting = new CalorieCounting(data);
        
        // when
        var actual = calorieCounting.GetCalorieCountForTopThreeElvesCarryingMost();
        
        // then
        Assert.Equal(expected, actual);
        _outputHelper.WriteLine($"The top three elves carries {actual} calories together");
    }
}
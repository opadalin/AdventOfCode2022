using AdventOfCode.Day1;
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

    [Fact]
    public void CanGetTheElfWithTheMostCalorieCount()
    {
        var calorieCounting = new CalorieCounting();
        var most = calorieCounting.GetCalorieCountForTheElfCarryingMost();
        _outputHelper.WriteLine($"Elf with the most calories has {most} calories");
    }

    [Fact]
    public void CanGetTheTopThreeElvesWithTheMostCalorieCount()
    {
        var calorieCounting = new CalorieCounting();
        var topThree = calorieCounting.GetCalorieCountForTopThreeElvesCarryingMost();
        _outputHelper.WriteLine($"Top three elves carries {topThree} calories");
    }
}
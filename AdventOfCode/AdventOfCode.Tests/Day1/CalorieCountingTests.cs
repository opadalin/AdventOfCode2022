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
    [InlineData("calories.txt", 65912, true)]
    [InlineData("1000\n2000\n3000\n\n4000\n5000\n6000\n\n7000\n8000\n9000\n\n10000", 24000, false)]
    public void CanGetTheElfWithTheMostCalorieCount(string inputData, int expected, bool readFromFile)
    {
        // given
        var data = readFromFile ? FileReader.ReadResource(inputData) : inputData;

        var sut = CalorieCountingBuilder.Create()
            .ExtractFoodFromInputData(data)
            .Build();

        // when
        var actual = sut.GetCalorieCountForTheElfCarryingMost();

        // then
        Assert.Equal(expected, actual);
        _outputHelper.WriteLine($"The elf with the most calories has {actual} calories");
    }

    [Theory(DisplayName = "Can calculate and display the sum of the top three elves carrying most calories")]
    [InlineData("calories.txt", 195625, true)]
    [InlineData("1000\n2000\n3000\n\n4000\n5000\n6000\n\n7000\n8000\n9000\n\n10000", 45000, false)]
    public void CanGetTheTopThreeElvesWithTheMostCalorieCount(string inputData, int expected, bool readFromFile)
    {
        // given
        var data = readFromFile ? FileReader.ReadResource(inputData) : inputData;

        var sut = CalorieCountingBuilder.Create()
            .ExtractFoodFromInputData(data)
            .Build();

        // when
        var actual = sut.GetCalorieCountForTopThreeElvesCarryingMost();

        // then
        Assert.Equal(expected, actual);
        _outputHelper.WriteLine($"The top three elves carries {actual} calories together");
    }
}
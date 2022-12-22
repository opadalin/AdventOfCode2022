using AdventOfCode.Day4;
using AdventOfCode.Tests.Helpers;
using Xunit;
using Xunit.Abstractions;

namespace AdventOfCode.Tests.Day4;

public class CampCleanupTest
{
    private readonly ITestOutputHelper _outputHelper;

    public CampCleanupTest(ITestOutputHelper outputHelper)
    {
        _outputHelper = outputHelper;
    }

    [Theory(DisplayName = "Get total number of pairs with fully overlapping assignments")]
    [InlineData("camp-cleanup.txt", 496, true)]
    [InlineData("2-4,6-8\n2-3,4-5\n5-7,7-9\n2-8,3-7\n6-6,4-6\n2-6,4-8", 2, false)]
    public void CanGetTotalNumberOfPairsWithFullyOverlappingAssignments(
        string inputData,
        int expected,
        bool readFromFile)
    {
        // given
        var data = readFromFile ? FileReader.ReadResource(inputData) : inputData;

        var sut = new CampCleanupService(data);

        // when
        var totalNumberOfPairsWithFullyOverlappingAssignments =
            sut.GetTotalNumberOfPairsWithFullyOverlappingAssignments();

        // then
        Assert.Equal(expected, totalNumberOfPairsWithFullyOverlappingAssignments);
        _outputHelper.WriteLine("Total number of pairs with fully overlapping assignments are " +
                                $"{totalNumberOfPairsWithFullyOverlappingAssignments}");
    }

    [Theory(DisplayName = "Get total number of pairs with any overlapping assignments")]
    [InlineData("camp-cleanup.txt", 847, true)]
    [InlineData("2-4,6-8\n2-3,4-5\n5-7,7-9\n2-8,3-7\n6-6,4-6\n2-6,4-8", 4, false)]
    public void CanGetAllPairsWithOverlappingAssignments(string inputData, int expected, bool readFromFile)
    {
        // given
        var data = readFromFile ? FileReader.ReadResource(inputData) : inputData;

        var sut = new CampCleanupService(data);

        // when
        var totalNumberOfPairsWithAnyOverlappingAssignments = sut.GetTotalNumberOfPairsWithAnyOverlappingAssignments();

        // then
        Assert.Equal(expected, totalNumberOfPairsWithAnyOverlappingAssignments);
        _outputHelper.WriteLine("Total number of pairs with any overlapping assignments are " +
                                $"{totalNumberOfPairsWithAnyOverlappingAssignments}");
    }
}
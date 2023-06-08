using AdventOfCode.Day8;
using AdventOfCode.Tests.Helpers;
using Xunit;
using Xunit.Abstractions;

namespace AdventOfCode.Tests.Day8;

public class TreetopTreeHouseTests
{
    private readonly ITestOutputHelper _outputHelper;

    public TreetopTreeHouseTests(ITestOutputHelper outputHelper)
    {
        _outputHelper = outputHelper;
    }

    [Theory(DisplayName = "How many trees are visible from outside the grid?")]
    [InlineData("treetop-tree-house.txt", 0, true)]
    [InlineData("30373\n25512\n65332\n33549\n35390", 21, false)]
    public void Part1(string inputData, int expected, bool readFromFile)
    {
        // given 
        var data = readFromFile ? FileReader.ReadResource(inputData) : inputData;
        var treeMatrix = TreetopTreeHouseService.CreateTreeMatrix(data);
        
        var sut = new TreetopTreeHouseService();

        // when
        var actual = sut.GetNumberOfVisibleTrees(treeMatrix);

        // then
        Assert.Equal(expected, actual);
        _outputHelper.WriteLine($"{actual}");
    }
}
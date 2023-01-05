using AdventOfCode.Day6;
using AdventOfCode.Day7;
using AdventOfCode.Tests.Helpers;
using Xunit;
using Xunit.Abstractions;

namespace AdventOfCode.Tests.Day7;

public class NoSpaceLeftOnDeviceTests
{
    private readonly ITestOutputHelper _outputHelper;

    public NoSpaceLeftOnDeviceTests(ITestOutputHelper outputHelper)
    {
        _outputHelper = outputHelper;
    }

    [Theory(DisplayName = "No Space Left On Device")]
    [InlineData("no-space-left-on-device.txt", 1427048, true)]
    [InlineData(@"$ cd /
$ ls
dir a
14848514 b.txt
8504156 c.dat
dir d
$ cd a
$ ls
dir e
29116 f
2557 g
62596 h.lst
$ cd e
$ ls
584 i
$ cd ..
$ cd ..
$ cd d
$ ls
4060174 j
8033020 d.log
5626152 d.ext
7214296 k", 95437, false)]
    public void Test(string inputData, long expected, bool readFromFile)
    {
        // given
        var data = readFromFile ? FileReader.ReadResource(inputData) : inputData;
        var fileSystemManager = new FileSystemManager();
        // when
        fileSystemManager.PopulateDirectories(data);

        var actual = fileSystemManager.CalculateTotalSumOfDirectoriesWithATotalSizeOfAtMost100000();

        // then
        Assert.Equal(expected, actual);
        _outputHelper.WriteLine($"{actual}");
    }
}
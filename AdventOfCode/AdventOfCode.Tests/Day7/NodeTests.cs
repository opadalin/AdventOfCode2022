using System.Collections.Generic;
using AdventOfCode.Day7;
using Xunit;

namespace AdventOfCode.Tests.Day7;

public class NodeTests
{
    [Theory]
    [InlineData("test.doc", 9, 12)]
    public void FilesShouldBeEqual(string name, int size1, int size2)
    {
        var node1 = new File(name, size1);
        var node2 = new File(name, size2);

        Assert.Equal(node1, node2);
    }

    [Theory]
    [InlineData("test.doc", "test.txt", 9)]
    public void FilesShouldNotBeEqual(string name1, string name2, int size)
    {
        var node1 = new File(name1, size);
        var node2 = new File(name2, size);

        Assert.NotEqual(node1, node2);
    }

    [Theory]
    [InlineData("test.doc")]
    public void DirectoriesShouldBeEqual(string name)
    {
        var parent = new Directory("/", null, new Dictionary<string, Node>());
        var node1 = new Directory(name, parent, null);
        var node2 = new Directory(name, parent, null);

        Assert.Equal(node1, node2);
    }

    [Theory]
    [InlineData("test.doc", "test.txt")]
    public void DirectoriesShouldNotBeEqual(string name1, string name2)
    {
        var parent = new Directory("/", null, new Dictionary<string, Node>());
        var node1 = new Directory(name1, parent, new Dictionary<string, Node>());
        var node2 = new Directory(name2, parent, null);

        Assert.NotEqual(node1, node2);
    }
}
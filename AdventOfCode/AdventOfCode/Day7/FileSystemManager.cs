using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode.Day7;

public class FileSystemManager
{
    private const string CommandPrefix = "$ ";
    private const string DirectoryPrefix = "dir ";

    private const string ChangeDirectoryCommand = "cd ";
    private const string ListCommand = "ls";
    private const string RootName = "/";
    private const string MoveUpDirectoryCommand = "..";

    public long TotalUsedSpace => _rootDirectory.GetSize();
    private long UnusedSpace => 70000000L - TotalUsedSpace;
    private long MinimumSpaceToDelete => 30000000L - UnusedSpace;

    private Directory _rootDirectory;

    public void PopulateDirectories(string inputData)
    {
        var data = inputData.Split(CommandPrefix, StringSplitOptions.RemoveEmptyEntries);
        Directory currentDirectory = null;
        foreach (var terminalOutput in data)
        {
            var output = Normalize(terminalOutput);

            ChangeDirectory(output, ref currentDirectory);

            if (!output.StartsWith(ListCommand))
            {
                continue;
            }

            var names = output.Split(";").Where(o => !o.Equals(ListCommand));
            foreach (var name in names)
            {
                if (name.StartsWith(DirectoryPrefix))
                {
                    var directoryName = GetDirectoryName(name);
                    var directory = new Directory(directoryName, currentDirectory, new Dictionary<string, Node>());
                    currentDirectory.Children.Add(directory.Name, directory);
                }
                else
                {
                    var file = GetFile(name);
                    currentDirectory.Children.Add(file.Name, file);
                }
            }
        }
    }

    private void ChangeDirectory(string output, ref Directory currentDirectory)
    {
        if (output.EndsWith(RootName))
        {
            var directoryName = GetDirectoryName(output);
            var directory = new Directory(directoryName, null, new Dictionary<string, Node>());
            _rootDirectory = directory;
            currentDirectory = _rootDirectory;
        }

        if (!output.StartsWith(ChangeDirectoryCommand))
        {
            return;
        }

        var directoryToChangeTo = output.Split(" ").Last();
        if (directoryToChangeTo.Equals(MoveUpDirectoryCommand))
        {
            currentDirectory = currentDirectory?.Parent;
        }

        if (currentDirectory?.Children.TryGetValue(directoryToChangeTo, out var node) ?? false)
        {
            currentDirectory = node as Directory;
        }
    }

    private static File GetFile(string name)
    {
        var fileProperties = name.Split(" ");
        var size = long.Parse(fileProperties[0]);
        var fileName = fileProperties[1];
        return new File(fileName, size);
    }

    private static string Normalize(string terminalOutput)
    {
        return terminalOutput.ReplaceLineEndings(";").TrimEnd(';');
    }

    private static string GetDirectoryName(string output)
    {
        var directoryName = output
            .Split(" ")
            .Last();
        return directoryName;
    }

    public long CalculateTotalSumOfDirectoriesWithATotalSizeOfAtMost100000()
    {
        var sum = 0L;

        Directory.Traverse(_rootDirectory, directory => sum += GetSizeForDirectoriesBelow100000InSize(directory));

        return sum;
    }


    private static long GetSizeForDirectoriesBelow100000InSize(Directory directory)
    {
        var sum = 0L;
        if (directory.IsAtMost100000InSize)
        {
            sum += directory.GetSize();
        }

        return sum;
    }

    private long GetSmallestSizeToDelete(Node node)
    {
        var sum = long.MaxValue;
        if (node.GetSize() >= MinimumSpaceToDelete)
        {
            sum = node.GetSize();
        }

        return sum;
    }

    public long GetSizeForTheSmallestDirectoryToDeleteBeforeUpdate()
    {
        var allBelowMinimumSize = new HashSet<long>();

        Directory.Traverse(_rootDirectory, directory => allBelowMinimumSize.Add(GetSmallestSizeToDelete(directory)));

        return allBelowMinimumSize.Min();
    }
}
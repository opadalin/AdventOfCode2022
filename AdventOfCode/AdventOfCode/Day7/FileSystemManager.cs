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

    private Directory _rootDirectory;

    public void PopulateDirectories(string inputData)
    {
        var data = inputData.Split(CommandPrefix, StringSplitOptions.RemoveEmptyEntries);
        Directory currentDirectory = null;
        foreach (var terminalOutput in data)
        {
            var output = Normalize(terminalOutput);


            currentDirectory = CurrentDirectory(output, currentDirectory);

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

    private Directory CurrentDirectory(string output, Directory currentDirectory)
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
            return currentDirectory;
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

        return currentDirectory;
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

        Directory.Traverse(_rootDirectory, x => sum += Calculate(x));

        return sum;
    }

    private static long Calculate(Node node)
    {
        var sum = 0L;
        if (node is Directory {IsAtMost100000InSize: true})
        {
            sum += node.GetSize();
        }

        return sum;
    }
}
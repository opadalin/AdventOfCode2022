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
    private const string GoToParentDirectoryCommand = "..";

    public long TotalUsedSpace => _rootDirectory.GetSize();
    private long UnusedSpace => 70000000L - TotalUsedSpace;
    private long MinimumSpaceToDelete => 30000000L - UnusedSpace;

    private Directory _rootDirectory;

    public void PopulateDirectories(string inputData)
    {
        var terminalOutputAsArray = inputData.Split(CommandPrefix, StringSplitOptions.RemoveEmptyEntries);
        Directory currentDirectory = null;
        foreach (var terminalOutput in terminalOutputAsArray)
        {
            var normalizedTerminalOutput = NormalizeOutput(terminalOutput);

            ChangeDirectory(normalizedTerminalOutput, ref currentDirectory);

            if (!normalizedTerminalOutput.StartsWith(ListCommand))
            {
                continue;
            }

            CreateFilesAndDirectories(normalizedTerminalOutput, ref currentDirectory);
        }
    }

    private static void CreateFilesAndDirectories(string terminalOutput, ref Directory currentDirectory)
    {
        var outputNames = terminalOutput.Split(";").Where(o => !o.Equals(ListCommand));
        foreach (var nameOutput in outputNames)
        {
            if (nameOutput.StartsWith(DirectoryPrefix))
            {
                var directory = Directory.Create(nameOutput, currentDirectory);
                currentDirectory.Children.Add(directory.Name, directory);
            }
            else
            {
                var file = File.Create(nameOutput);
                currentDirectory.Children.Add(file.Name, file);
            }
        }
    }

    private void ChangeDirectory(string terminalOutput, ref Directory currentDirectory)
    {
        if (!terminalOutput.StartsWith(ChangeDirectoryCommand))
        {
            return;
        }

        if (terminalOutput.EndsWith(RootName))
        {
            _rootDirectory = Directory.Create(RootName);
            currentDirectory = _rootDirectory;
            return;
        }

        var directoryToChangeTo = terminalOutput.Split(" ").Last();
        if (directoryToChangeTo.Equals(GoToParentDirectoryCommand))
        {
            currentDirectory = currentDirectory?.Parent;
            return;
        }

        if (currentDirectory?.Children.TryGetValue(directoryToChangeTo, out var node) ?? false)
        {
            currentDirectory = node as Directory;
        }
    }

    private static string NormalizeOutput(string terminalOutput)
    {
        return terminalOutput.ReplaceLineEndings(";").TrimEnd(';');
    }

    public long CalculateTotalSumOfDirectoriesWithATotalSizeOfAtMost100000()
    {
        var sum = 0L;

        Directory.Traverse(_rootDirectory, directory =>
        {
            sum += directory.IsLessThanOrEqual100000InSize ? directory.GetSize() : 0;
        });

        return sum;
    }

    public long GetSizeForTheSmallestDirectoryToDeleteBeforeUpdate()
    {
        var allBelowMinimumSize = new HashSet<long>();

        Directory.Traverse(_rootDirectory, directory =>
        {
            if (directory.GetSize() >= MinimumSpaceToDelete)
            {
                allBelowMinimumSize.Add(directory.GetSize());
            }
        });

        return allBelowMinimumSize.Min();
    }
}
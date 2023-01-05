using System;

namespace AdventOfCode.Day7;

public abstract class Node
{
    public string Name { get; }

    protected Node(string name)
    {
        if (string.IsNullOrEmpty(name))
        {
            throw new ArgumentNullException(nameof(name));
        }

        Name = name;
    }

    public abstract long GetSize();
}
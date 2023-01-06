using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode.Day7;

public class Directory : Node
{
    private bool IsRoot { get; }
    public Directory Parent { get; }
    public Dictionary<string, Node> Children { get; }
    public bool IsLessThanOrEqual100000InSize => GetSize() <= 100000L;

    private Directory(string name, Directory parent = null) : base(name)
    {
        Children = new Dictionary<string, Node>();
        IsRoot = Name.Equals("/");
        if (!IsRoot)
        {
            Parent = parent ?? throw new ArgumentNullException(nameof(parent));
        }
    }

    public static Directory Create(string name, Directory parent = null)
    {
        var directoryName = name.Split(" ").Last();
        return new Directory(directoryName, parent);
    }

    public override long GetSize()
    {
        return Children.Values.Sum(node => node.GetSize());
    }

    public override string ToString()
    {
        var kind = IsRoot ? "Root" : "Directory";
        return $"Kind: {kind}, Name: {Name}, Size: {GetSize()}";
    }

    public static void Traverse(Directory directory, DirectoryAction action)
    {
        action(directory);
        foreach (var child in directory.Children.Values.Where(n => n is Directory))
        {
            Traverse(child as Directory, action);
        }
    }
}

public delegate void DirectoryAction(Directory directory);
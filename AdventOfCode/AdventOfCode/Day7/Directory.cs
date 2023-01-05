using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode.Day7;

public class Directory : Node
{
    private const long MaxSize = 100000;
    private bool IsRoot { get; }
    public Directory Parent { get; }
    public Dictionary<string, Node> Children { get; }
    public bool IsAtMost100000InSize => GetSize() <= MaxSize;

    public Directory(string name, Directory parent, Dictionary<string, Node> children) : base(name)
    {
        Children = children;
        IsRoot = Name.Equals("/");
        if (!IsRoot)
        {
            Parent = parent ?? throw new ArgumentNullException(nameof(parent));
        }
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

    public static void Traverse(Directory directory, Visitor visitor)
    {
        visitor(directory);
        foreach (var child in directory.Children.Values.Where(n => n is Directory))
        {
            var dir = child as Directory;
            Traverse(dir, visitor);
        }
    }
}

public delegate void Visitor(Directory directory);
using System;

namespace AdventOfCode.Day8;

public class Tree
{
    private const int MinHeight = 0;
    private const int MaxHeight = 9;
    public int Height { get; }

    private Tree(char height)
    {
        if (!int.TryParse(height.ToString(), out var value))
        {
            throw new ArgumentException($"{height} is not a valid height");
        }

        if (value is < MinHeight or > MaxHeight)
        {
            throw new ArgumentOutOfRangeException($"{height} is an invalid tree height. " +
                                                  $"Must be a height between {MinHeight} and {MaxHeight}.");
        }

        Height = value;
    }

    public static Tree Create(char height)
    {
        return new Tree(height);
    }

    public override string ToString()
    {
        return $"Tree with {Height.ToString()} in height";
    }
}

public struct Boundaries
{
    public bool VisibleFromTop { get; set; }
    public bool VisibleFromBottom { get; set; }
    public bool VisibleFromLeft { get; set; }
    public bool VisibleFromRight { get; set; }
}
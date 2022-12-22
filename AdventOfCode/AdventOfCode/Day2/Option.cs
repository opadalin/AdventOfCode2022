using System;

namespace AdventOfCode.Day2;

public enum Option
{
    Rock,
    Paper,
    Scissors
}

public static class OptionMapper
{
    public static Option MapToOption(string value)
    {
        return value switch
        {
            "A" => Option.Rock,
            "X" => Option.Rock,
            "B" => Option.Paper,
            "Y" => Option.Paper,
            "C" => Option.Scissors,
            "Z" => Option.Scissors,
            _ => throw new NotSupportedException($"{value} is not supported")
        };
    }
}
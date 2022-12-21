using System;

namespace AdventOfCode.Day2;

public class Selection
{
    public Option Option { get; }

    public Selection(string inputString)
    {
        AssertValidInput(inputString);

        var option = ToOption(inputString);
        Option = option;
    }

    public Selection(Option option)
    {
        Option = option;
    }

    public bool Beats(Selection other)
    {
        switch (Option)
        {
            case Option.Rock when other.Option == Option.Scissors:
            case Option.Scissors when other.Option == Option.Paper:
            case Option.Paper when other.Option == Option.Rock:
                return true;
            case Option.None:
            default:
                return false;
        }
    }

    public bool IsDraw(Selection other)
    {
        return Option == other.Option;
    }

    private static Option ToOption(string inputString)
    {
        return inputString.ToUpperInvariant() switch
        {
            "A" => Option.Rock,
            "X" => Option.Rock,
            "B" => Option.Paper,
            "Y" => Option.Paper,
            "C" => Option.Scissors,
            "Z" => Option.Scissors,
            _ => throw new ArgumentOutOfRangeException(nameof(inputString))
        };
    }

    private static void AssertValidInput(string inputString)
    {
        if (string.IsNullOrWhiteSpace(inputString))
        {
            throw new ArgumentNullException(nameof(inputString));
        }

        if (!string.Equals(inputString, "X", StringComparison.OrdinalIgnoreCase)
            && !string.Equals(inputString, "Y", StringComparison.OrdinalIgnoreCase)
            && !string.Equals(inputString, "Z", StringComparison.OrdinalIgnoreCase)
            && !string.Equals(inputString, "A", StringComparison.OrdinalIgnoreCase)
            && !string.Equals(inputString, "B", StringComparison.OrdinalIgnoreCase)
            && !string.Equals(inputString, "C", StringComparison.OrdinalIgnoreCase))
        {
            throw new ArgumentException($"{inputString} is not a valid value");
        }
    }

    public override string ToString()
    {
        return Option.ToString();
    }
}
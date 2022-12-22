using System;

namespace AdventOfCode.Day2;

public class Selection
{
    public Option Option { get; }

    public Selection(string inputString)
    {
        AssertValidInput(inputString);

        Option = inputString switch
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
            default:
                return false;
        }
    }

    public bool IsDraw(Selection other)
    {
        return Option == other.Option;
    }

    private static void AssertValidInput(string inputString)
    {
        if (string.IsNullOrWhiteSpace(inputString))
        {
            throw new ArgumentNullException(nameof(inputString));
        }

        if (!inputString.Equals("X")
            && !inputString.Equals("Y")
            && !inputString.Equals("Z")
            && !inputString.Equals("A")
            && !inputString.Equals("B")
            && !inputString.Equals("C"))
        {
            throw new ArgumentException($"{inputString} is not a valid value");
        }
    }

    public override string ToString()
    {
        return Option.ToString();
    }
}
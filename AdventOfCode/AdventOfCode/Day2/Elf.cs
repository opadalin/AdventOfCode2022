using System;

namespace AdventOfCode.Day2;

public class Elf 
{
    private readonly string _name;

    public Elf(string name)
    {
        _name = name;
    }

    public void Choose(string choice)
    {
        var rps = ToRps(choice);
        var selection = new Selection(rps);

        Score = rps switch
        {
            Option.Rock => 1,
            Option.Paper => 2,
            Option.Scissors => 3,
            _ => Score
        };

        Selection = selection;
    }

    public void AddToScore(int score)
    {
        Score += score;
    }

    public int Score { get; private set; }
    public Selection Selection { get; private set; }

    private static Option ToRps(string inputString)
    {
        return inputString switch
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

    public override string ToString()
    {
        return _name;
    }
}
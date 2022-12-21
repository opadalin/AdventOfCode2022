using System;

namespace AdventOfCode.Day2;

public class Elf
{
    private readonly string _name;

    public Elf(string name)
    {
        if (string.IsNullOrWhiteSpace(name))
        {
            throw new ArgumentNullException(nameof(name));
        }

        _name = name;
    }

    public int Score { get; private set; }
    public Selection Selection { get; private set; }

    public void Choose(Selection selection)
    {
        Selection = selection;
        Score = selection.Option switch
        {
            Option.Rock => 1,
            Option.Paper => 2,
            Option.Scissors => 3,
            _ => Score
        };
    }

    public void AddToScore(int score)
    {
        Score += score;
    }

    public override string ToString()
    {
        return _name;
    }
}
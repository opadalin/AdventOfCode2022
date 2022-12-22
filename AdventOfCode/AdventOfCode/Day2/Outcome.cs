using System;

namespace AdventOfCode.Day2;

public enum Outcome
{
    Draw,
    Defeat,
    Victory
}

public static class OutcomeMapper
{
    public static Outcome MapToOutcome(string value)
    {
        return value switch
        {
            "X" => Outcome.Defeat,
            "Y" => Outcome.Draw,
            "Z" => Outcome.Victory,
            _ => throw new NotSupportedException($"{value} is not supported")
        };
    }
}
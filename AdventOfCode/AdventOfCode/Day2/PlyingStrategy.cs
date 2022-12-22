using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode.Day2;

public abstract class PlayingStrategy
{
    public abstract IEnumerable<Round> Play();

    protected static IEnumerable<InputData> ExtractInputData(string inputData)
    {
        return inputData
            .Split(Environment.NewLine)
            .Select(round => new InputData(round.Split(' ')[0], round.Split(' ')[1]));
    }
}

public record InputData(string Input1, string Input2);
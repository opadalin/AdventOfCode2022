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

public class InputData
{
    public InputData(string input1, string input2)
    {
        ArgumentNullException.ThrowIfNull(input1);
        ArgumentNullException.ThrowIfNull(input2);
        Input1 = input1;
        Input2 = input2;
    }

    public string Input1 { get; }
    public string Input2 { get; }
}
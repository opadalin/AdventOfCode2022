using System;
using System.Collections.Generic;

namespace AdventOfCode.Day2;

public class Part1Strategy : PlayingStrategy
{
    private readonly IEnumerable<InputData> _inputData;

    public Part1Strategy(string inputData)
    {
        if (string.IsNullOrEmpty(inputData))
        {
            throw new ArgumentNullException(nameof(inputData));
        }

        _inputData = ExtractInputData(inputData);
    }

    public override IEnumerable<Round> Play()
    {
        var rounds = new List<Round>();
        foreach (var data in _inputData)
        {
            var opponent = new Elf(new Selection(data.Input1));
            var me = new Elf(new Selection(data.Input2));
            rounds.Add(Round.Setup(opponent, me).Play());
        }

        return rounds;
    }
}
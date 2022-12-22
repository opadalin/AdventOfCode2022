using System;
using System.Collections.Generic;

namespace AdventOfCode.Day2;

public class Part2Strategy : PlayingStrategy
{
    private readonly IEnumerable<InputData> _inputData;

    public Part2Strategy(string inputData)
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
            var opponentsSelection = new Selection(data.Input1);
            var opponent = new Elf(opponentsSelection);

            var howTheRoundNeedsToEnd = new HowTheRoundNeedsToEnd(data.Input2, opponentsSelection);
            var correctSelection = howTheRoundNeedsToEnd.PickCorrectSelection();

            var me = new Elf(correctSelection);
            rounds.Add(Round.Setup(opponent, me).Play());
        }

        return rounds;
    }
}
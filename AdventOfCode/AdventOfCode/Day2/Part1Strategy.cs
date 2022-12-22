using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode.Day2;

public class Part1Strategy : PlayingStrategy
{
    private readonly IEnumerable<StrategyGuide> _strategyGuide;

    public Part1Strategy(string inputData)
    {
        if (string.IsNullOrEmpty(inputData))
        {
            throw new ArgumentNullException(nameof(inputData));
        }

        var extractedInputData = ExtractInputData(inputData);
        _strategyGuide = extractedInputData.Select(data => new StrategyGuide(data));
    }

    public override IEnumerable<Round> Play()
    {
        var rounds = new List<Round>();
        foreach (var guide in _strategyGuide)
        {
            var opponent = new Elf(new Selection(guide.Option1));
            var me = new Elf(new Selection(guide.Option2));
            rounds.Add(Round.Setup(opponent, me).Play());
        }

        return rounds;
    }

    private sealed class StrategyGuide
    {
        public Option Option1 { get; }
        public Option Option2 { get; }

        public StrategyGuide(InputData inputData)
        {
            Option1 = OptionMapper.MapToOption(inputData.Input1);
            Option2 = OptionMapper.MapToOption(inputData.Input2);
        }
    }
}
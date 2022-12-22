using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;

namespace AdventOfCode.Day2;

public class Part2Strategy : PlayingStrategy
{
    private readonly IEnumerable<StrategyGuide> _strategyGuide;
    
    private readonly ImmutableList<Selection> _selections = ImmutableList.Create(
        new Selection(Option.Rock),
        new Selection(Option.Paper),
        new Selection(Option.Scissors));

    public Part2Strategy(string inputData)
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
            var opponentsSelection = new Selection(guide.Option);
            var opponent = new Elf(opponentsSelection);
            
            var correctSelection = PickCorrectSelection(guide.Outcome, opponentsSelection);

            var me = new Elf(correctSelection);
            rounds.Add(Round.Setup(opponent, me).Play());
        }

        return rounds;
    }
    
    private Selection PickCorrectSelection(Outcome outcome, Selection selection)
    {
        return outcome switch
        {
            Outcome.Draw => selection,
            Outcome.Defeat => _selections.FirstOrDefault(s =>
                !s.Beats(selection) && !s.IsDraw(selection)),
            Outcome.Victory => _selections.FirstOrDefault(s =>
                s.Beats(selection) && !s.IsDraw(selection)),
            _ => throw new NotSupportedException(outcome.ToString())
        };
    }

    private sealed class StrategyGuide
    {
        public Option Option { get; }
        public Outcome Outcome { get; }

        public StrategyGuide(InputData inputData)
        {
            ArgumentNullException.ThrowIfNull(inputData);
            Option = OptionMapper.MapToOption(inputData.Input1);
            Outcome = OutcomeMapper.MapToOutcome(inputData.Input2);
        }
    }
}
using System;
using System.Collections.Immutable;
using System.Linq;

namespace AdventOfCode.Day2;

public class HowTheRoundNeedsToEnd
{
    private readonly ImmutableList<Selection> _selections = ImmutableList.Create(
        new Selection(Option.Rock),
        new Selection(Option.Paper),
        new Selection(Option.Scissors));

    private readonly Outcome _outcome;
    private readonly Selection _opponentsSelection;

    public HowTheRoundNeedsToEnd(string inputString, Selection opponentsSelection)
    {
        AssertValidInput(inputString);

        _outcome = inputString.ToUpperInvariant() switch
        {
            "X" => Outcome.Defeat,
            "Y" => Outcome.Draw,
            "Z" => Outcome.Victory,
            _ => throw new ArgumentOutOfRangeException(nameof(inputString))
        };

        ArgumentNullException.ThrowIfNull(opponentsSelection);
        _opponentsSelection = opponentsSelection;
    }

    public Selection PickCorrectSelection()
    {
        return _outcome switch
        {
            Outcome.Draw => _opponentsSelection,
            Outcome.Defeat => _selections.FirstOrDefault(s =>
                !s.Beats(_opponentsSelection) && !s.IsDraw(_opponentsSelection)),
            Outcome.Victory => _selections.FirstOrDefault(s =>
                s.Beats(_opponentsSelection) && !s.IsDraw(_opponentsSelection)),
            _ => throw new ArgumentOutOfRangeException(_outcome.ToString())
        };
    }

    private static void AssertValidInput(string inputString)
    {
        if (string.IsNullOrWhiteSpace(inputString))
        {
            throw new ArgumentNullException(nameof(inputString));
        }

        if (!string.Equals(inputString, "X", StringComparison.OrdinalIgnoreCase)
            && !string.Equals(inputString, "Y", StringComparison.OrdinalIgnoreCase)
            && !string.Equals(inputString, "Z", StringComparison.OrdinalIgnoreCase))
        {
            throw new ArgumentException($"{inputString} is not a valid value");
        }
    }
}
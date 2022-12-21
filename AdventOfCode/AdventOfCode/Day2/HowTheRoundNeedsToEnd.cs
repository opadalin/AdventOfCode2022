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

    public HowTheRoundNeedsToEnd(string inputString, Selection opponentsSelection)
    {
        AssertValidInput(inputString);

        Outcome = inputString.ToUpperInvariant() switch
        {
            "X" => Outcome.Defeat,
            "Y" => Outcome.Draw,
            "Z" => Outcome.Victory,
            _ => throw new ArgumentOutOfRangeException(nameof(inputString))
        };

        ArgumentNullException.ThrowIfNull(opponentsSelection);
        OpponentsSelection = opponentsSelection;
    }


    public Selection PickCorrectSelection()
    {
        switch (Outcome)
        {
            case Outcome.Draw:
                return OpponentsSelection;
            case Outcome.Defeat:
            {
                var losingSelection = _selections.FirstOrDefault(s => !s.Beats(OpponentsSelection));
                return losingSelection;
            }
            case Outcome.Victory:
            {
                var winningSelection = _selections.FirstOrDefault(s => s.Beats(OpponentsSelection));
                return winningSelection;
            }
            default:
                throw new ArgumentOutOfRangeException(Outcome.ToString());
        }
    }

    public Outcome Outcome { get; }
    public Selection OpponentsSelection { get; }

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
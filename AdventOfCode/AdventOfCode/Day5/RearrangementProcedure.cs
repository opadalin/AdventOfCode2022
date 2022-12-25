using System;

namespace AdventOfCode.Day5;

public class RearrangementProcedure
{
    private const int MinMoveAmount = 1;
    private const int MinCargoHold = 1;
    private const int MaxCargoHold = 9;
    public int Amount { get; }
    public int From { get; }
    public int To { get; }

    public RearrangementProcedure(int amount, int from, int to)
    {
        ValidateInput(amount, from, to);
        Amount = amount;
        From = from;
        To = to;
    }

    private static void ValidateInput(int amount, int from, int to)
    {
        if (amount < MinMoveAmount)
        {
            throw new ArgumentOutOfRangeException(nameof(amount));
        }

        if (from is < MinCargoHold or > MaxCargoHold)
        {
            throw new ArgumentOutOfRangeException(nameof(from));
        }

        if (to is < MinCargoHold or > MaxCargoHold)
        {
            throw new ArgumentOutOfRangeException(nameof(to));
        }
    }
}
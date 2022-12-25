namespace AdventOfCode.Day5;

public class RearrangementProcedure
{
    public int Amount { get; }
    public int From { get; }
    public int To { get; }

    public RearrangementProcedure(int amount, int from, int to)
    {
        Amount = amount;
        From = from;
        To = to;
    }
}
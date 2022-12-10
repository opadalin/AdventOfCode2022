namespace AdventOfCode.Day2;

public class Selection
{
    private Option Option { get; }

    public Selection(Option option)
    {
        Option = option;
    }

    public bool Beats(Selection other)
    {
        switch (Option)
        {
            case Option.Rock when other.Option == Option.Scissors:
            case Option.Scissors when other.Option == Option.Paper:
            case Option.Paper when other.Option == Option.Rock:
                return true;
            case Option.None:
            default:
                return false;
        }
    }
    
    public bool IsDraw(Selection other)
    {
        return Option == other.Option;
    }

    public override string ToString()
    {
        return Option.ToString();
    }
}
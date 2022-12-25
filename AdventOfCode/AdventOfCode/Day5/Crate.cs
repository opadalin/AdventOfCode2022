namespace AdventOfCode.Day5;

public class Crate
{
    private readonly string _value;

    public Crate(string value)
    {
        _value = value;
    }

    public override string ToString()
    {
        return _value.Replace("[", "").Replace("]", "");
    }
}
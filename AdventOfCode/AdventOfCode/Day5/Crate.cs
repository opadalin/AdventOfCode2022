using System;

namespace AdventOfCode.Day5;

public class Crate
{
    private readonly string _value;

    public Crate(string value)
    {
        if (string.IsNullOrEmpty(value))
        {
            throw new ArgumentNullException(nameof(value));
        }

        _value = value;
    }

    public override string ToString()
    {
        return _value.Replace("[", "").Replace("]", "");
    }
}
using System.Collections.Generic;
using System.Text;

namespace AdventOfCode.Day5;

public abstract class Crane
{
    public abstract IDictionary<int, Stack<Crate>> Move();

    public string GetTopCratesInCargo(IDictionary<int, Stack<Crate>> cargo)
    {
        var sb = new StringBuilder();

        foreach (var crates in cargo.Values)
        {
            var crate = crates.Pop();
            sb.Append(crate);
        }

        return sb.ToString();
    }
}
using System;
using System.Collections.Generic;
using System.Text;

namespace AdventOfCode.Day5;

public class SupplyStacksService
{
    private readonly ICrane _crane;

    public SupplyStacksService(ICrane crane)
    {
        ArgumentNullException.ThrowIfNull(crane);
        _crane = crane;
    }

    public string RearrangeCrates()
    {
        var cargo = _crane.Move();
        return GetTopCratesInCargo(cargo);
    }

    private static string GetTopCratesInCargo(IDictionary<int, Stack<Crate>> cargo)
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
using System;

namespace AdventOfCode.Day5;

public class SupplyStacksService
{
    private readonly Crane _crane;

    public SupplyStacksService(Crane crane)
    {
        ArgumentNullException.ThrowIfNull(crane);
        _crane = crane;
    }

    public string RearrangeCrates()
    {
        var cargo = _crane.Move();
        return _crane.GetTopCratesInCargo(cargo);
    }
}
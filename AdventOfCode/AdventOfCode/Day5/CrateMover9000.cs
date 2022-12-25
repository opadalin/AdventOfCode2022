using System;
using System.Collections.Generic;

namespace AdventOfCode.Day5;

public class CrateMover9000 : Crane
{
    private readonly IDictionary<int, Stack<Crate>> _cargo;
    private readonly IEnumerable<RearrangementProcedure> _rearrangementProcedures;

    public CrateMover9000(
        IDictionary<int, Stack<Crate>> cargo,
        IEnumerable<RearrangementProcedure> rearrangementProcedures)
    {
        ArgumentNullException.ThrowIfNull(cargo);
        ArgumentNullException.ThrowIfNull(rearrangementProcedures);

        _cargo = cargo;
        _rearrangementProcedures = rearrangementProcedures;
    }

    public override IDictionary<int, Stack<Crate>> Move()
    {
        foreach (var rearrangementProcedure in _rearrangementProcedures)
        {
            if (!_cargo.TryGetValue(rearrangementProcedure.From, out var cratesFrom))
            {
                return _cargo;
            }

            for (var i = 0; i < rearrangementProcedure.Amount; i++)
            {
                var crateToBeMoved = cratesFrom.Pop();
                if (_cargo.TryGetValue(rearrangementProcedure.To, out var cratesTo))
                {
                    cratesTo.Push(crateToBeMoved);
                }
            }
        }

        return _cargo;
    }
}
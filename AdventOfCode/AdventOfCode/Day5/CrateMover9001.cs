using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode.Day5;

public class CrateMover9001 : Crane
{
    private readonly IDictionary<int, Stack<Crate>> _cargo;
    private readonly IEnumerable<RearrangementProcedure> _rearrangementProcedures;

    public CrateMover9001(
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


            if (!_cargo.TryGetValue(rearrangementProcedure.To, out var cratesTo))
            {
                continue;
            }

            var cratesToBeMoved = cratesFrom.Take(rearrangementProcedure.Amount).Reverse();
            foreach (var crateToBeMoved in cratesToBeMoved)
            {
                cratesFrom.Pop();
                cratesTo.Push(crateToBeMoved);
            }
        }

        return _cargo;
    }
}
using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode.Day5;

public class SupplyStacksExtractor
{
    private readonly IEnumerable<string> _cargoData;
    private readonly IEnumerable<string> _rearrangementProcedureData;

    public SupplyStacksExtractor(string inputData)
    {
        if (string.IsNullOrEmpty(inputData))
        {
            throw new ArgumentNullException(nameof(inputData));
        }

        var dataSets = inputData.Split("\n\n");
        _cargoData = GetCargoData(dataSets);
        _rearrangementProcedureData = GetRearrangementProcedureData(dataSets);
    }

    public IEnumerable<RearrangementProcedure> ExtractRearrangementProcedures()
    {
        return _rearrangementProcedureData
            .Select(data => data
                .Split(new[] {"move ", " from ", " to "}, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse).ToArray())
            .Select(p => new RearrangementProcedure(p[0], p[1], p[2]));
    }

    public IDictionary<int, Stack<Crate>> ExtractCargo()
    {
        var sortedCrateRows = GetSortedCrateRows(_cargoData);

        var map = new Dictionary<int, Stack<Crate>>();

        foreach (var crateRow in sortedCrateRows)
        {
            for (var i = 0; i < crateRow.Count; i++)
            {
                var crate = crateRow.ElementAt(i);
                var column = i + 1;
                if (map.TryGetValue(column, out var existingStack))
                {
                    if (!string.IsNullOrEmpty(crate))
                    {
                        existingStack.Push(new Crate(crate));
                    }
                }
                else
                {
                    var newStack = new Stack<Crate>();
                    if (string.IsNullOrEmpty(crate))
                    {
                        map.Add(column, newStack);
                        continue;
                    }

                    newStack.Push(new Crate(crate));
                    map.Add(column, newStack);
                }
            }
        }

        return map;
    }

    private static IEnumerable<string> GetRearrangementProcedureData(IEnumerable<string> dataSets)
    {
        return dataSets.Last().Split("\n");
    }

    private static IEnumerable<string> GetCargoData(IEnumerable<string> dataSets)
    {
        var crateData = dataSets.First().Split("\n");
        crateData = crateData.Take(crateData.Length - 1).ToArray();
        return crateData;
    }

    private static LinkedList<LinkedList<string>> GetSortedCrateRows(IEnumerable<string> crateData)
    {
        var listOfCrateRows = new LinkedList<LinkedList<string>>();
        foreach (var crates in crateData)
        {
            var crateRow = new LinkedList<string>();
            for (var i = 0; i < crates.Length; i += 4)
            {
                var crate = crates.Substring(i, Math.Min(4, crates.Length - i)).Trim();
                crateRow.AddLast(crate);
            }

            listOfCrateRows.AddFirst(crateRow);
        }

        return listOfCrateRows;
    }
}
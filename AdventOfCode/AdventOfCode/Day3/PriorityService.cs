using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode.Day3;

public class PriorityService
{
    private readonly string _inputData;

    public PriorityService(string inputData)
    {
        if (string.IsNullOrWhiteSpace(inputData))
        {
            throw new ArgumentNullException(nameof(inputData));
        }

        _inputData = inputData;
    }

    public int GetPriorityScore()
    {
        return GetRucksacks(_inputData)
            .Select(rucksack => rucksack.GetIntersection())
            .Select(intersection => intersection.Priority)
            .Sum();
    }

    private static IEnumerable<Rucksack> GetRucksacks(string inputData)
    {
        var completeInventory = inputData.Split(Environment.NewLine);

        return completeInventory.Select(GetRucksack).ToList();
    }

    private static Rucksack GetRucksack(string inventory)
    {
        var halfLength = inventory.Length / 2;

        var first = inventory[..halfLength];
        var second = inventory[halfLength..];

        return new Rucksack(new Compartment(first), new Compartment(second));
    }
}
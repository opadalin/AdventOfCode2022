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

    public int GetGroupBadgePriorityScore()
    {
        var allRucksacks = GetRucksacks(_inputData).ToList();
        var groups = new List<List<Rucksack>>();
        for (var i = 0; i < allRucksacks.Count; i++)
        {
            if ((i + 1) % 3 == 0)
            {
                groups.Add(new List<Rucksack>
                {
                    allRucksacks[i - 2],
                    allRucksacks[i - 1],
                    allRucksacks[i]
                });
            }
        }

        return groups.Select(GetGroupBadge).Sum(item => item.Priority);
    }

    private static Item GetGroupBadge(IReadOnlyList<Rucksack> group)
    {
        var rucksack1 = group[0];
        var rucksack2 = group[1];
        var rucksack3 = group[2];
        return rucksack1.GetAllItems
            .Intersect(rucksack2.GetAllItems)
            .Intersect(rucksack3.GetAllItems)
            .FirstOrDefault();
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
using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode.Day3;

public class Rucksack
{
    public Compartment First { get; }
    public Compartment Second { get; }

    public Rucksack(Compartment first, Compartment second)
    {
        ArgumentNullException.ThrowIfNull(first);
        ArgumentNullException.ThrowIfNull(second);

        First = first;
        Second = second;
    }

    public Item GetIntersection() => First.Items.Intersect(Second.Items).SingleOrDefault();

    public IEnumerable<Item> GetAllItems => First.Items.Concat(Second.Items);
}
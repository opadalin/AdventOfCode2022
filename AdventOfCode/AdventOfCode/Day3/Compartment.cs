using System;
using System.Collections.Generic;
using System.Text;

namespace AdventOfCode.Day3;

public class Compartment
{
    private const byte UpperCaseLetterOffset = 38;
    private const byte LowerCaseLetterOffset = 96;

    public IEnumerable<Item> Items { get; }

    public Compartment(string itemsAsString)
    {
        if (string.IsNullOrWhiteSpace(itemsAsString))
        {
            throw new ArgumentNullException(nameof(itemsAsString));
        }

        Items = GetItems(itemsAsString);
    }

    private static IEnumerable<Item> GetItems(string itemsAsString)
    {
        var asciiBytes = Encoding.ASCII.GetBytes(itemsAsString);

        var items = new List<Item>();
        for (var i = 0; i < asciiBytes.Length; i++)
        {
            var value = itemsAsString[i];
            int priority;

            if (char.IsUpper(value))
            {
                priority = asciiBytes[i] - UpperCaseLetterOffset;
            }
            else
            {
                priority = asciiBytes[i] - LowerCaseLetterOffset;
            }

            items.Add(new Item(value, priority));
        }

        return items;
    }
}
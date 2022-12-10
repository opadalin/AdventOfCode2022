using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode.Day1;

public class Elf
{
    private readonly List<int> _calories;

    public Elf(List<int> calories)
    {
        _calories = calories;
    }

    public int GetCalories()
    {
        return _calories.Sum();
    }
}
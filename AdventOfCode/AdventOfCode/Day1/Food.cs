using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode.Day1;

public class Food
{
    private readonly List<int> _calories;

    public Food(List<int> calories)
    {
        _calories = calories;
    }

    public int GetTotalCalorieCount()
    {
        return _calories.Sum();
    }
}
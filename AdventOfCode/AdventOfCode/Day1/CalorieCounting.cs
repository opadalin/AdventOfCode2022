using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode.Day1;

public class CalorieCounting
{
    private readonly List<Food> _food;

    public CalorieCounting(List<Food> food)
    {
        ArgumentNullException.ThrowIfNull(food);
        _food = food;
    }

    public int GetCalorieCountForTheElfCarryingMost()
    {
        return _food.MaxBy(elf => elf.GetTotalCalorieCount()).GetTotalCalorieCount();
    }

    public int GetCalorieCountForTopThreeElvesCarryingMost()
    {
        var calorieCountForTopThreeElvesCarryingMost =
            _food.OrderByDescending(elf => elf.GetTotalCalorieCount()).Take(3);
        return calorieCountForTopThreeElvesCarryingMost.Sum(x => x.GetTotalCalorieCount());
    }
}
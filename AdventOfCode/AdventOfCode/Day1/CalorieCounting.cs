using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode.Day1;

public class CalorieCounting
{
    private readonly List<Elf> _elves;
    
    public CalorieCounting(string inputData)
    {
        _elves = new List<Elf>();
        var calorieList = inputData.Split(Environment.NewLine);
        
        var calories = new List<int>();
        foreach (var calorieCount in calorieList)
        {
            if (int.TryParse(calorieCount, out var calorie))
            {
                calories.Add(calorie);
            }
            
            if (string.IsNullOrEmpty(calorieCount))
            {
                var elf = new Elf(calories);
                _elves.Add(elf);
                calories = new List<int>();
            }
        }
    }

    public int GetCalorieCountForTheElfCarryingMost()
    {
        return _elves.MaxBy(elf => elf.GetCalories())!.GetCalories();
    }
    
    public int GetCalorieCountForTopThreeElvesCarryingMost()
    {
        var calorieCountForTopThreeElvesCarryingMost = _elves.OrderByDescending(elf => elf.GetCalories()).Take(3);
        return  calorieCountForTopThreeElvesCarryingMost.Sum(x => x.GetCalories());
    }
}
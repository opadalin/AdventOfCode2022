using System;
using System.Collections.Generic;

namespace AdventOfCode.Day1;

public class CalorieCountingBuilder
{
    private List<Food> _food;

    private CalorieCountingBuilder()
    {
    }

    public static CalorieCountingBuilder Create()
    {
        return new CalorieCountingBuilder();
    }

    public CalorieCountingBuilder ExtractFoodFromInputData(string inputData)
    {
        if (string.IsNullOrEmpty(inputData))
        {
            throw new ArgumentNullException(nameof(inputData));
        }

        var dataAsStringArray = inputData.Split(Environment.NewLine);
        var food = new List<Food>();
        var calories = new List<int>();
        foreach (var item in dataAsStringArray)
        {
            if (int.TryParse(item, out var calorie))
            {
                calories.Add(calorie);
            }

            if (!string.IsNullOrEmpty(item))
            {
                continue;
            }

            food.Add(new Food(calories));
            calories = new List<int>();
        }

        _food = food;
        return this;
    }

    public CalorieCounting Build()
    {
        return new CalorieCounting(_food);
    }
}
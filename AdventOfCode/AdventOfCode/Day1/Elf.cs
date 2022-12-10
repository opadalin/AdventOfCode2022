namespace AdventOfCode.Day1;

public class Elf
{
    public List<int> Calories { get; }

    public Elf(List<int> calories)
    {
        Calories = calories;
    }

    public int GetCalories()
    {
        return Calories.Sum();
    }
}
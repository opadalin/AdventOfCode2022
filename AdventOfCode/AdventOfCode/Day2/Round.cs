using System;

namespace AdventOfCode.Day2;

public class Round
{
    public Elf Contestant1 { get; }
    public Elf Contestant2 { get; }

    private Round(Elf contestant1, Elf contestant2)
    {
        ArgumentNullException.ThrowIfNull(contestant1);
        ArgumentNullException.ThrowIfNull(contestant2);

        Contestant1 = contestant1;
        Contestant2 = contestant2;
    }

    public static Round Setup(Elf contestant1, Elf contestant2)
    {
        return new Round(contestant1, contestant2);
    }

    public Round Play()
    {
        if (Contestant1.Selection.IsDraw(Contestant2.Selection))
        {
            Draw(Contestant1, Contestant2);
            return this;
        }

        AppointWinner(Contestant1.Selection.Beats(Contestant2.Selection) ? Contestant1 : Contestant2);
        return this;
    }

    private static void Draw(params Elf[] elves)
    {
        foreach (var elf in elves)
        {
            elf.AddToScore(3);
        }
    }

    private static void AppointWinner(Elf elf)
    {
        elf.AddToScore(6);
    }

    public override string ToString()
    {
        return $"{Contestant1.Selection} vs {Contestant2.Selection}";
    }
}
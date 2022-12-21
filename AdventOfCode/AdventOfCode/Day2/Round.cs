using System;
using System.Collections.Generic;

namespace AdventOfCode.Day2;

public class Round
{
    public Elf Contestant1 { get; }
    public Elf Contestant2 { get; }

    public IEnumerable<Elf> Contestants { get; }

    public Round(Elf contestant1, Elf contestant2)
    {
        ArgumentNullException.ThrowIfNull(contestant1);
        ArgumentNullException.ThrowIfNull(contestant2);

        Contestant1 = contestant1;
        Contestant2 = contestant2;

        Contestants = new List<Elf>
        {
            Contestant1,
            Contestant2
        };
    }

    public void PlayRound()
    {
        if (Contestant1.Selection.IsDraw(Contestant2.Selection))
        {
            Draw(Contestant1, Contestant2);
            return;
        }

        AppointWinner(Contestant1.Selection.Beats(Contestant2.Selection) ? Contestant1 : Contestant2);
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
}
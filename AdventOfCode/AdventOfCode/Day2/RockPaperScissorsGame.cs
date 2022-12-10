using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode.Day2;

public class RockPaperScissorsGame
{
    private readonly List<Round> _rounds;

    public RockPaperScissorsGame(string data)
    {
        _rounds = new List<Round>();

        var rounds = data
            .Split($"{Environment.NewLine}")
            .Select(round => (round.Split(' ')[0], round.Split(' ')[1]));

        foreach (var (selection1, selection2) in rounds)
        {
            var opponent = new Elf("Bob");
            var me = new Elf("opadalin");
            opponent.Choose(selection1);
            me.Choose(selection2);
            var round = new Round(opponent, me);
            round.PlayRound();
            _rounds.Add(round);
        }
    }

    public int CalculateScoreForMe()
    {
        return _rounds.Sum(round => round.Me.Score);
    }
}
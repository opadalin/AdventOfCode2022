using System.Collections.Generic;

namespace AdventOfCode.Day2;

public class Part1Strategy : IPlayingStrategy
{
    public IEnumerable<Round> PlayRounds(IEnumerable<InputData> inputData)
    {
        var rounds = new List<Round>();
        foreach (var data in inputData)
        {
            var opponent = new Elf("Bob");
            var me = new Elf("opadalin");
            opponent.Choose(new Selection(data.Input1));
            me.Choose(new Selection(data.Input2));
            var round = new Round(opponent, me);
            round.PlayRound();
            rounds.Add(round);
        }

        return rounds;
    }
}
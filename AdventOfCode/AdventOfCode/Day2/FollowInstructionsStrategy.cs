using System.Collections.Generic;

namespace AdventOfCode.Day2;

public class FollowInstructionsStrategy : IPlayingStrategy
{
    public IEnumerable<Round> PlayRounds(IEnumerable<InputData> inputData)
    {
        var rounds = new List<Round>();
        foreach (var data in inputData)
        {
            var opponent = new Elf("Bob");
            var me = new Elf("opadalin");
            var opponentsSelection = new Selection(data.Input1);
            opponent.Choose(opponentsSelection);

            var howTheRoundNeedsToEnd = new HowTheRoundNeedsToEnd(data.Input2, opponentsSelection);
            var correctSelection = howTheRoundNeedsToEnd.PickCorrectSelection();

            me.Choose(correctSelection);
            var round = new Round(opponent, me);
            round.PlayRound();
            rounds.Add(round);
        }

        return rounds;
    }
}
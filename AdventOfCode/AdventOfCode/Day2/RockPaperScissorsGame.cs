using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode.Day2;

public class RockPaperScissorsGame
{
    private readonly IEnumerable<InputData> _inputData;
    private readonly IPlayingStrategy _playingStrategy;

    public RockPaperScissorsGame(string data, IPlayingStrategy playingStrategy)
    {
        ArgumentNullException.ThrowIfNull(data);
        ArgumentNullException.ThrowIfNull(playingStrategy);

        _playingStrategy = playingStrategy;

        _inputData = data
            .Split($"{Environment.NewLine}")
            .Select(round => new InputData(round.Split(' ')[0], round.Split(' ')[1]));
    }

    public int Play()
    {
        var rounds = _playingStrategy.PlayRounds(_inputData);
        return rounds.Sum(round => round.Contestant2.Score);
    }
}
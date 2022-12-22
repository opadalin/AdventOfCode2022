using System;
using System.Linq;

namespace AdventOfCode.Day2;

public class RockPaperScissors
{
    private readonly PlayingStrategy _playingStrategy;

    public RockPaperScissors(PlayingStrategy playingStrategy)
    {
        ArgumentNullException.ThrowIfNull(playingStrategy);
        _playingStrategy = playingStrategy;
    }

    public int Play()
    {
        var rounds = _playingStrategy.Play();
        return rounds.Sum(round => round.Contestant2.Score);
    }
}
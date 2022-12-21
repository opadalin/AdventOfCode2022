using System.Collections.Generic;

namespace AdventOfCode.Day2;

public interface IPlayingStrategy
{
    public IEnumerable<Round> PlayRounds(IEnumerable<InputData> inputData);
}
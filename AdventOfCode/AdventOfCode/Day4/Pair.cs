using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode.Day4;

public class Pair
{
    private readonly HashSet<int> _assignmentsForFirstElf;
    private readonly HashSet<int> _assignmentsForSecondElf;

    public Pair(string first, string second)
    {
        var firstStartIndex = int.Parse(first.Split('-')[0]);
        var firstCount = int.Parse(first.Split('-')[1]) - firstStartIndex + 1;

        var secondStartIndex = int.Parse(second.Split('-')[0]);
        var secondCount = int.Parse(second.Split('-')[1]) - secondStartIndex + 1;

        _assignmentsForFirstElf = Enumerable.Range(firstStartIndex, firstCount).ToHashSet();
        _assignmentsForSecondElf = Enumerable.Range(secondStartIndex, secondCount).ToHashSet();
    }

    public bool HasFullyOverlappingAssignments()
    {
        return _assignmentsForFirstElf.IsSubsetOf(_assignmentsForSecondElf) ||
               _assignmentsForSecondElf.IsSubsetOf(_assignmentsForFirstElf);
    }
}
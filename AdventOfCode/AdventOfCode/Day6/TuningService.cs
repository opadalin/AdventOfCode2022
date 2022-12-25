using System.Linq;

namespace AdventOfCode.Day6;

public class TuningService
{
    private readonly char[] _markers;

    public TuningService(string inputData)
    {
        _markers = new char[inputData.Length];
        for (var i = 0; i < inputData.Length; i++)
        {
            _markers[i] = inputData[i];
        }
    }

    public int DetectMarker(int chunkSize)
    {
        var chunkStartIndex = 0;
        for (var currentMarker = chunkSize; currentMarker < _markers.Length - 1; currentMarker++)
        {
            if (HasDuplicateMarkers(chunkStartIndex, currentMarker))
            {
                chunkStartIndex++;
            }
            else
            {
                return currentMarker;
            }
        }

        return -1;
    }

    private bool HasDuplicateMarkers(int chunkStartIndex, int marker)
    {
        return _markers[chunkStartIndex..marker].GroupBy(x => x).Any(g => g.Count() > 1);
    }
}
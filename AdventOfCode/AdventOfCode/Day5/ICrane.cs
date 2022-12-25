using System.Collections.Generic;

namespace AdventOfCode.Day5;

public interface ICrane
{
    IDictionary<int, Stack<Crate>> Move();
}
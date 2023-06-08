using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AdventOfCode.Day8;

public class Grid
{
    public Dictionary<int, Dictionary<int, Tree>> Rows { get; }
    public Dictionary<int, Dictionary<int, Tree>> Columns { get; }

    public int Width { get; }
    public int Height { get; }

    private readonly LinkedList<LinkedList<Tree>> _treeMatrix;

    public Grid(LinkedList<LinkedList<Tree>> treeMatrix)
    {
        ArgumentNullException.ThrowIfNull(treeMatrix);
        _treeMatrix = treeMatrix;

        var rows = new Dictionary<int, Dictionary<int, Tree>>();
        var columns = new Dictionary<int, Dictionary<int, Tree>>();

        for (var i = 0; i < treeMatrix.Count; i++)
        {
            var row = new Dictionary<int, Tree>();
            var treeRow = treeMatrix.ElementAt(i);

            for (var j = 0; j < treeRow.Count; j++)
            {
                var tree = treeRow.ElementAt(j);
                row.Add(j, tree);
            }

            rows.Add(i, row);
        }

        for (var i = 0; i < treeMatrix.First().Count; i++)
        {
            var column = new Dictionary<int, Tree>();
            for (var j = 0; j < treeMatrix.Count; j++)
            {
                var tree = treeMatrix.ElementAt(j).ElementAt(i);

                column.Add(j, tree);
            }

            columns.Add(i, column);
        }

        Rows = rows;
        Columns = columns;

        Width = Columns.Count;
        Height = Rows.Count;
    }

    public override string ToString()
    {
        var sb = new StringBuilder();
        foreach (var treeRow in _treeMatrix)
        {
            foreach (var tree in treeRow)
            {
                sb.Append(tree);
            }

            sb.Append(Environment.NewLine);
        }

        return sb.ToString();
    }
}
using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode.Day8;

public class TreetopTreeHouseService
{
    public static LinkedList<LinkedList<Tree>> CreateTreeMatrix(string inputData)
    {
        var rows = inputData.Split(Environment.NewLine, StringSplitOptions.RemoveEmptyEntries);

        var treeMatrix = new LinkedList<LinkedList<Tree>>();
        foreach (var row in rows)
        {
            var characters = row.ToCharArray();
            var treeRow = new LinkedList<Tree>();
            foreach (var character in characters)
            {
                var tree = Tree.Create(character);
                treeRow.AddLast(tree);
            }

            treeMatrix.AddLast(treeRow);
        }

        return treeMatrix;
    }

    public int GetNumberOfVisibleTrees(LinkedList<LinkedList<Tree>> treeMatrix)
    {
        var grid = new Grid(treeMatrix);

        var gridString = grid.ToString();
        Console.Write(gridString);
        var numberOfTreesVisibleAroundTheEdge = GetNumberOfTreesVisibleAroundTheEdge(treeMatrix);

        //var x = Get(treeMatrix);

        return numberOfTreesVisibleAroundTheEdge;
    }

    private int Get(Grid grid)
    {
        var sum = 0;

        for (var i = 1; i < grid.Height -1; i++)
        {
            if (grid.Rows.TryGetValue(i, out var row))
            {
                
            }

        }
        

        return sum;
    }

    private static int GetNumberOfTreesVisibleAroundTheEdge(LinkedList<LinkedList<Tree>> treeMatrix)
    {
        var firstRow = treeMatrix.First().Count;
        var lastRow = treeMatrix.Last().Count;
        var firstAndLastColumn = treeMatrix.Count * 2;
        return firstRow + lastRow + firstAndLastColumn;
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
public static class PascalsTriangle
{
    private static int pascal(int row, int col)
    {
        if (col == 0 || row == col)
        {
            return 1;
        }
        return pascal(row - 1, col - 1) + pascal(row - 1, col);
    }
    public static IEnumerable<IEnumerable<int>> Calculate(int rows)
    {
        return Enumerable.Range(0, rows).Select(r => Enumerable.Range(0, r + 1).Select(c => pascal(r, c)));
    }
}
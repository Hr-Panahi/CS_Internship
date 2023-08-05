using System;
using System.Collections.Generic;
using System.Linq;

public class HighScores
{
    private readonly IEnumerable<int> _highScores;
    public HighScores(List<int> list)
    {
        _highScores = list;
    }
    public List<int> Scores()
    {
        return _highScores.ToList();
    }
    public int Latest()
    {
        return _highScores.Last();
    }
    public int PersonalBest()
    {
        return _highScores.Max();
    }
    public List<int> PersonalTopThree()
    {
        return _highScores.OrderByDescending(x => x).Take(3).ToList();
    }
}
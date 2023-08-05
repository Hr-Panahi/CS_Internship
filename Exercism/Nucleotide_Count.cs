using System;
using System.Collections.Generic;

public static class NucleotideCount
{
    public static IDictionary<char, int> Count(string sequence)
    {
        Dictionary<char, int> nucleotideDict = new Dictionary<char, int>()
        {
            {'A', 0 },
            {'C', 0 },
            {'G', 0 },
            {'T', 0 }
        };

        foreach (char ch in sequence)
        {
            if (nucleotideDict.ContainsKey(ch))
            {
                nucleotideDict[ch]++;
            }
            else
                throw new ArgumentException();
        }
        return nucleotideDict;
    }
}
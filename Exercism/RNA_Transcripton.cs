using System;
using System.Collections.Generic;

public static class RnaTranscription
{
    public static string ToRna(string nucleotide)
    {
        var myList = new List<Char>();
        var outList = new List<Char>();
        foreach (Char ch in nucleotide)
            myList.Add(ch);

        foreach (Char i in myList)
        {
            if (i == 'G')
                outList.Add('C');
            if (i == 'C')
                outList.Add('G');
            if (i == 'T')
                outList.Add('A');
            if (i == 'A')
                outList.Add('U');
        }

        
        string finalout = "";
        foreach (Char final in outList)
            finalout += $"{final}";
        return finalout;

    }
}
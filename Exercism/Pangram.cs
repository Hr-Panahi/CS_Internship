using System;
using System.Collections.Generic;

public static class Pangram
{
    public static bool IsPangram(string input)
    {
            var lowerCaseInput = input.ToLower();
        
            var letterList = new List<char> { };

            foreach (char ch in lowerCaseInput)
            {
                if (Char.IsLetter(ch))
                    if (!letterList.Contains(ch))
                        letterList.Add(ch);
            }

            if (letterList.Count == 26)
            {
                return true;
            }
            else
                return false;
    }
}

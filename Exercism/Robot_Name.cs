using System;
using System.Collections.Generic;

public class Robot
{
    private static readonly Random random = new Random();
    private static readonly HashSet<string> usedNames = new HashSet<string>();

    private string name;

    public string Name
    {
        get
        {
            if (name == null)
            {
                Reset();
            }
            return name;
        }
    }

    public void Reset()
    {
        // Generate a new unique name for the robot
        do
        {
            name = GenerateRandomName();
        }
        while (!usedNames.Add(name)); // Continue generating until a unique name is found
    }

    private string GenerateRandomName()
    {
        // Generate two random uppercase letters followed by three random digits
        char[] letters = "ABCDEFGHIJKLMNOPQRSTUVWXYZ".ToCharArray();
        string randomLetters = $"{letters[random.Next(letters.Length)]}{letters[random.Next(letters.Length)]}";
        string randomDigits = random.Next(1000).ToString("D3");

        return $"{randomLetters}{randomDigits}";
    }
}

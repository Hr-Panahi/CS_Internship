using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

public static class Tournament
{
    public static void Tally(Stream inStream, Stream outStream)
    {
        // Read input from inStream
        using (StreamReader reader = new StreamReader(inStream))
        {
            string input = reader.ReadToEnd();
            string output = Tally(input);

            // Write output to outStream
            using (StreamWriter writer = new StreamWriter(outStream))
            {
                writer.Write(output);
            }
        }
    }

    public static string Tally(string rows)
    {
        // Read all lines from input
        string[] lines = rows.Split('\n', StringSplitOptions.RemoveEmptyEntries);

        // Dictionary to store team standings
        Dictionary<string, TeamStats> league = new Dictionary<string, TeamStats>();

        // Process each match result
        foreach (string matchResult in lines)
        {
            string[] parts = matchResult.Split(';');
            string team1 = parts[0];
            string team2 = parts[1];
            string outcome = parts[2];

            // Update team stats based on outcome
            UpdateTeamStats(league, team1, team2, outcome);
        }

        // Calculate points for each team
        CalculatePoints(league);

        // Sort teams by points (descending), matches won, and then by name (ascending)
        var sortedTeams = league.OrderByDescending(kv => kv.Value.Points)
                                   .ThenByDescending(kv => kv.Value.Win)
                                   .ThenBy(kv => kv.Key);

        // Generate the output string
        string output = "Team                           | MP |  W |  D |  L |  P\n";
        foreach (var team in sortedTeams)
        {
            output += $"{team.Key,-30} | {team.Value.Played,2} | {team.Value.Win,2} | {team.Value.Draw,2} | {team.Value.Lose,2} | {team.Value.Points,2}\n";
        }

        return output.Trim();
    }

    static void UpdateTeamStats(Dictionary<string, TeamStats> league, string team, string opponent, string outcome)
    {
        if (!league.ContainsKey(team))
        {
            league[team] = new TeamStats();
        }
        if (!league.ContainsKey(opponent))
        {
            league[opponent] = new TeamStats();
        }

        league[team].Played++;
        league[opponent].Played++;

        if (outcome == "win")
        {
            league[team].Win++;
            league[opponent].Lose++;
        }
        else if (outcome == "draw")
        {
            league[team].Draw++;
            league[opponent].Draw++;
        }
        else if (outcome == "loss")
        {
            league[team].Lose++;
            league[opponent].Win++;
        }
    }

    static void CalculatePoints(Dictionary<string, TeamStats> league)
    {
        foreach (var kvp in league)
        {
            kvp.Value.Points = kvp.Value.Win * 3 + kvp.Value.Draw;
        }
    }
    class TeamStats
    {
        public int Played { get; set; }
        public int Win { get; set; }
        public int Draw { get; set; }
        public int Lose { get; set; }
        public int Points { get; set; }
    }
}



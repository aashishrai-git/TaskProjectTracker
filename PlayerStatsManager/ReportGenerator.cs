namespace PlayerStatsManager;

public class ReportGenerator
{
    public void GenerateMostActiveReport(IEnumerable<Player> players)
    {
        var sorted = BubbleSort(players.ToList(), (a, b) => b.HoursPlayed.CompareTo(a.HoursPlayed));
        Console.WriteLine("Most Active Players (by Hours Played):");
        foreach (var player in sorted.Take(5))
        {
            Console.WriteLine($"{player.Username}: {player.HoursPlayed} hours");
        }
    }

    public void GenerateTopScoresReport(IEnumerable<Player> players)
    {
        var sorted = BubbleSort(players.ToList(), (a, b) => b.HighScore.CompareTo(a.HighScore));
        Console.WriteLine("Top Scores:");
        foreach (var player in sorted.Take(5))
        {
            Console.WriteLine($"{player.Username}: {player.HighScore}");
        }
    }

    private List<Player> BubbleSort(List<Player> list, Comparison<Player> comparison)
    {
        for (int i = 0; i < list.Count - 1; i++)
        {
            for (int j = 0; j < list.Count - i - 1; j++)
            {
                if (comparison(list[j], list[j + 1]) > 0)
                {
                    (list[j], list[j + 1]) = (list[j + 1], list[j]);
                }
            }
        }
        return list;
    }
}

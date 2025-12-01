using System.Text.Json.Serialization;

namespace PlayerStatsManager;

public class Player
{
    public string Id { get; set; }
    public string Username { get; set; }
    public string? Email { get; set; }
    public DateTime DateJoined { get; set; }
    public double HoursPlayed { get; set; }
    public int HighScore { get; set; }
    public int TotalGamesPlayed { get; set; }

    public Player(string id, string username, string? email = null)
    {
        Id = id;
        Username = username;
        Email = email;
        DateJoined = DateTime.Now;
        HoursPlayed = 0;
        HighScore = 0;
        TotalGamesPlayed = 0;
    }

    public void UpdateHours(double additionalHours)
    {
        if (additionalHours < 0) throw new ArgumentException("Hours cannot be negative.");
        HoursPlayed += additionalHours;
    }

    public void UpdateHighScore(int newScore)
    {
        if (newScore < 0) throw new ArgumentException("Score cannot be negative.");
        if (newScore > HighScore) HighScore = newScore;
    }

    public void IncrementGamesPlayed()
    {
        TotalGamesPlayed++;
    }
}

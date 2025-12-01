using System.Text.Json;

namespace PlayerStatsManager;

public class DataPersistence
{
    private const string DataFile = "players.json";

    public void SavePlayers(IEnumerable<Player> players)
    {
        try
        {
            var json = JsonSerializer.Serialize(players, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(DataFile, json);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error saving data: {ex.Message}");
        }
    }

    public IEnumerable<Player> LoadPlayers()
    {
        if (!File.Exists(DataFile))
        {
            return new List<Player>();
        }

        try
        {
            var json = File.ReadAllText(DataFile);
            return JsonSerializer.Deserialize<List<Player>>(json) ?? new List<Player>();
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error loading data: {ex.Message}. Starting with empty data.");
            return new List<Player>();
        }
    }
}

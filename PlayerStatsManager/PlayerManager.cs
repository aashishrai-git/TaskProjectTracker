using System.Collections.Generic;

namespace PlayerStatsManager;

public class PlayerManager
{
    private readonly Dictionary<string, Player> _players = new();
    private readonly DataPersistence _dataPersistence;

    public PlayerManager(DataPersistence dataPersistence)
    {
        _dataPersistence = dataPersistence;
    }

    public void LoadData()
    {
        var players = _dataPersistence.LoadPlayers();
        foreach (var player in players)
        {
            _players[player.Id] = player;
        }
    }

    public void SaveData()
    {
        _dataPersistence.SavePlayers(_players.Values);
    }

    public void AddPlayer(string id, string username, string? email = null)
    {
        if (string.IsNullOrWhiteSpace(id)) throw new ArgumentException("ID cannot be empty.");
        if (string.IsNullOrWhiteSpace(username)) throw new ArgumentException("Username cannot be empty.");
        if (_players.ContainsKey(id)) throw new InvalidOperationException("Player ID already exists.");

        var player = new Player(id, username, email);
        _players[id] = player;
        Logger.Instance.Log($"Player added: ID={id}, Username={username}");
    }

    public Player? SearchById(string id)
    {
        return _players.TryGetValue(id, out var player) ? player : null;
    }

    public Player? SearchByUsername(string username)
    {
        // Linear search
        foreach (var player in _players.Values)
        {
            if (player.Username.Equals(username, StringComparison.OrdinalIgnoreCase))
            {
                return player;
            }
        }
        return null;
    }

    public void UpdatePlayerStats(string id, double additionalHours, int newScore)
    {
        var player = SearchById(id);
        if (player == null) throw new KeyNotFoundException("Player not found.");

        player.UpdateHours(additionalHours);
        player.UpdateHighScore(newScore);
        player.IncrementGamesPlayed();
        Logger.Instance.Log($"Stats updated for player {id}: Hours +{additionalHours}, Score {newScore}");
    }

    public IEnumerable<Player> GetAllPlayers()
    {
        return _players.Values;
    }
}

using System;

namespace PlayerStatsManager;

public class MenuController
{
    private readonly PlayerManager _playerManager;
    private readonly ReportGenerator _reportGenerator;

    public MenuController(PlayerManager playerManager, ReportGenerator reportGenerator)
    {
        _playerManager = playerManager;
        _reportGenerator = reportGenerator;
    }

    public void Run()
    {
        while (true)
        {
            Console.Clear();
            Console.WriteLine("=== Game Stats Manager ===");
            Console.WriteLine("1. Add new player");
            Console.WriteLine("2. Update player stats");
            Console.WriteLine("3. Search player by ID");
            Console.WriteLine("4. Search player by username");
            Console.WriteLine("5. View most active players");
            Console.WriteLine("6. View top scoring players");
            Console.WriteLine("7. Save & Exit");
            Console.Write("Choose an option: ");

            var choice = Console.ReadLine()?.Trim();
            switch (choice)
            {
                case "1":
                    AddPlayer();
                    break;
                case "2":
                    UpdatePlayerStats();
                    break;
                case "3":
                    SearchById();
                    break;
                case "4":
                    SearchByUsername();
                    break;
                case "5":
                    ViewMostActive();
                    break;
                case "6":
                    ViewTopScores();
                    break;
                case "7":
                    _playerManager.SaveData();
                    Console.WriteLine("Data saved. Exiting...");
                    return;
                default:
                    Console.WriteLine("Invalid option. Press any key to continue.");
                    Console.ReadKey();
                    break;
            }
        }
    }

    private void AddPlayer()
    {
        Console.Write("Enter Player ID: ");
        var id = Console.ReadLine()?.Trim();
        Console.Write("Enter Username: ");
        var username = Console.ReadLine()?.Trim();
        Console.Write("Enter Email (optional): ");
        var email = Console.ReadLine()?.Trim();
        if (string.IsNullOrWhiteSpace(email)) email = null;

        try
        {
            _playerManager.AddPlayer(id!, username!, email);
            Console.WriteLine("Player added successfully.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
        Console.WriteLine("Press any key to continue.");
        Console.ReadKey();
    }

    private void UpdatePlayerStats()
    {
        Console.Write("Enter Player ID: ");
        var id = Console.ReadLine()?.Trim();
        Console.Write("Enter additional hours played: ");
        if (!double.TryParse(Console.ReadLine(), out var hours))
        {
            Console.WriteLine("Invalid hours.");
            Console.ReadKey();
            return;
        }
        Console.Write("Enter new score: ");
        if (!int.TryParse(Console.ReadLine(), out var score))
        {
            Console.WriteLine("Invalid score.");
            Console.ReadKey();
            return;
        }

        try
        {
            _playerManager.UpdatePlayerStats(id!, hours, score);
            Console.WriteLine("Stats updated successfully.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
        Console.WriteLine("Press any key to continue.");
        Console.ReadKey();
    }

    private void SearchById()
    {
        Console.Write("Enter Player ID: ");
        var id = Console.ReadLine()?.Trim();
        var player = _playerManager.SearchById(id!);
        if (player != null)
        {
            Console.WriteLine($"ID: {player.Id}, Username: {player.Username}, Email: {player.Email}, Hours: {player.HoursPlayed}, High Score: {player.HighScore}, Games: {player.TotalGamesPlayed}");
        }
        else
        {
            Console.WriteLine("Player not found.");
        }
        Console.WriteLine("Press any key to continue.");
        Console.ReadKey();
    }

    private void SearchByUsername()
    {
        Console.Write("Enter Username: ");
        var username = Console.ReadLine()?.Trim();
        var player = _playerManager.SearchByUsername(username!);
        if (player != null)
        {
            Console.WriteLine($"ID: {player.Id}, Username: {player.Username}, Email: {player.Email}, Hours: {player.HoursPlayed}, High Score: {player.HighScore}, Games: {player.TotalGamesPlayed}");
        }
        else
        {
            Console.WriteLine("Player not found.");
        }
        Console.WriteLine("Press any key to continue.");
        Console.ReadKey();
    }

    private void ViewMostActive()
    {
        _reportGenerator.GenerateMostActiveReport(_playerManager.GetAllPlayers());
        Console.WriteLine("Press any key to continue.");
        Console.ReadKey();
    }

    private void ViewTopScores()
    {
        _reportGenerator.GenerateTopScoresReport(_playerManager.GetAllPlayers());
        Console.WriteLine("Press any key to continue.");
        Console.ReadKey();
    }
}

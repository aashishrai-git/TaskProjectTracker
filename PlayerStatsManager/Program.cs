using PlayerStatsManager;

class Program
{
    static void Main(string[] args)
    {
        var dataPersistence = new DataPersistence();
        var playerManager = new PlayerManager(dataPersistence);
        var reportGenerator = new ReportGenerator();
        var menuController = new MenuController(playerManager, reportGenerator);

        playerManager.LoadData();

        menuController.Run();
    }
}

namespace PlayerStatsManager;

public class Logger
{
    private static Logger? _instance;
    private static readonly object _lock = new();
    private const string LogFile = "logs.txt";

    private Logger() { }

    public static Logger Instance
    {
        get
        {
            if (_instance == null)
            {
                lock (_lock)
                {
                    _instance ??= new Logger();
                }
            }
            return _instance;
        }
    }

    public void Log(string message)
    {
        try
        {
            var logEntry = $"{DateTime.Now}: {message}";
            File.AppendAllText(LogFile, logEntry + Environment.NewLine);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Logging error: {ex.Message}");
        }
    }
}

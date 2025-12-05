using System;

public class Program
{
    static void Main(string[] args)
    {
        TaskManager taskManager = new TaskManager();

        // Load tasks if they exist
        try
        {
            taskManager.LoadTasksFromJson();
        }
        catch (FileNotFoundException ex)
        {
            Console.WriteLine("Error: File not found.");
        }
        catch (Exception ex)
        {
            Console.WriteLine("An unexpected error occurred: " + ex.Message);
        }

        while (true)
        {
            Console.Clear();
            Console.WriteLine("Task & Project Tracker");
            Console.WriteLine("1. Add Task");
            Console.WriteLine("2. Update Task Status");
            Console.WriteLine("3. Search Task");
            Console.WriteLine("4. Sort Tasks by Due Date");
            Console.WriteLine("5. Generate Report");
            Console.WriteLine("6. Exit");
            Console.Write("Choose an option: ");
            var choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    AddTask(taskManager);
                    Console.WriteLine("Press any key to continue...");
                    Console.ReadKey();
                    break;
                case "2":
                    UpdateTaskStatus(taskManager);
                    Console.WriteLine("Press any key to continue...");
                    Console.ReadKey();
                    break;
                case "3":
                    SearchTask(taskManager);
                    Console.WriteLine("Press any key to continue...");
                    Console.ReadKey();
                    break;
                case "4":
                    taskManager.SortTasksByDueDate();
                    Console.WriteLine("Tasks sorted by due date.");
                    Console.WriteLine("Press any key to continue...");
                    Console.ReadKey();
                    break;
                case "5":
                    taskManager.ExportReport();
                    Console.WriteLine("Report generated successfully.");
                    Console.WriteLine("Press any key to continue...");
                    Console.ReadKey();
                    break;
                case "6":
                    taskManager.SaveTasksToJson();
                    return;
            }
        }
    }

    static void AddTask(TaskManager taskManager)
    {
        try
        {
            Console.Write("Enter Task ID: ");
            string taskId = Console.ReadLine();
            Console.Write("Enter Task Name: ");
            string taskName = Console.ReadLine();
            Console.Write("Enter Due Date (YYYY-MM-DD): ");
            DateTime dueDate;
            if (!DateTime.TryParse(Console.ReadLine(), out dueDate))
            {
                Console.WriteLine("Invalid date format. Using today's date.");
                dueDate = DateTime.Now;
            }
            Console.Write("Enter Priority (High/Medium/Low): ");
            string priority = Console.ReadLine();
            Console.Write("Enter Assignee: ");
            string assignee = Console.ReadLine();
            Console.Write("Enter Status (To-Do/In Progress/Done): ");
            string status = Console.ReadLine();

            Task task = new Task(taskId, taskName, dueDate, priority, assignee, status);
            taskManager.AddTask(task);
            Console.WriteLine("Task added successfully.");
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error adding task: " + ex.Message);
        }
    }

    static void UpdateTaskStatus(TaskManager taskManager)
    {
        Console.Write("Enter Task ID to update status: ");
        string taskId = Console.ReadLine();
        Console.Write("Enter new status (To-Do/In Progress/Done): ");
        string status = Console.ReadLine();
        taskManager.UpdateTaskStatus(taskId, status);
    }

    static void SearchTask(TaskManager taskManager)
    {
        Console.Write("Enter Task ID or Assignee to search: ");
        string searchTerm = Console.ReadLine();
        var task = taskManager.SearchTask(searchTerm);
        if (task != null)
        {
            Console.WriteLine($"Task Found: {task.TaskId} - {task.TaskName}, {task.Status}");
        }
        else
        {
            Console.WriteLine("Task not found.");
        }
    }
}

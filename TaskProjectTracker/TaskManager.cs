using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Newtonsoft.Json;

public class TaskManager
{
    private List<Task> tasks;

    public TaskManager()
    {
        tasks = new List<Task>();
    }

    // Add a new task
    public void AddTask(Task task)
    {
        tasks.Add(task);
        LogAction($"Task {task.TaskId} created.");
    }

    // Update an existing task's status
    public void UpdateTaskStatus(string taskId, string newStatus)
    {
        Task task = tasks.FirstOrDefault(t => t.TaskId == taskId);
        if (task != null)
        {
            task.Status = newStatus;
            LogAction($"Task {taskId} status updated to {newStatus}.");
        }
    }

    // Search tasks by ID or Assignee
    public Task SearchTask(string searchTerm)
    {
        return tasks.FirstOrDefault(t => t.TaskId == searchTerm || t.Assignee == searchTerm);
    }

    // Sort tasks by Due Date
    public void SortTasksByDueDate()
    {
        tasks = tasks.OrderBy(t => t.DueDate).ToList();
    }

    // Log actions to TXT file
    private void LogAction(string message)
    {
        File.AppendAllText("task_log.txt", $"{DateTime.Now}: {message}\n");
    }

    // Export all tasks to a report (CSV format)
    public void ExportReport()
    {
        using (var writer = new StreamWriter("task_report.csv"))
        {
            writer.WriteLine("TaskId,TaskName,DueDate,Priority,Assignee,Status");
            foreach (var task in tasks)
            {
                writer.WriteLine($"{task.TaskId},{task.TaskName},{task.DueDate},{task.Priority},{task.Assignee},{task.Status}");
            }
        }
    }

    // Save tasks to JSON
    public void SaveTasksToJson()
    {
        var json = JsonConvert.SerializeObject(tasks, Formatting.Indented);
        File.WriteAllText("tasks.json", json);
    }

    // Load tasks from JSON
    public void LoadTasksFromJson()
    {
        if (File.Exists("tasks.json"))
        {
            var json = File.ReadAllText("tasks.json");
            tasks = JsonConvert.DeserializeObject<List<Task>>(json);
        }
    }

    // For testing purposes, expose tasks
    public List<Task> GetAllTasks()
    {
        return tasks;
    }
}

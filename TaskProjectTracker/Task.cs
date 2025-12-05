using System;

public class Task
{
    public string TaskId { get; set; }
    public string TaskName { get; set; }
    public DateTime DueDate { get; set; }
    public string Priority { get; set; }
    public string Assignee { get; set; }
    public string Status { get; set; } // To-Do, In Progress, Done

    public Task() { }

    public Task(string taskId, string taskName, DateTime dueDate, string priority, string assignee, string status)
    {
        TaskId = taskId;
        TaskName = taskName;
        DueDate = dueDate;
        Priority = priority;
        Assignee = assignee;
        Status = status;
    }
}

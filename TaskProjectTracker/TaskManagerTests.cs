using System;
using System.Collections.Generic;
using Xunit;

public class TaskManagerTests
{
    [Fact]
    public void AddTask_ShouldAddTaskToList()
    {
        // Arrange
        TaskManager taskManager = new TaskManager();
        Task task = new Task("T001", "Test Task", DateTime.Now.AddDays(1), "High", "John Doe", "To-Do");

        // Act
        taskManager.AddTask(task);

        // Assert
        Assert.Contains(task, taskManager.GetAllTasks());
    }

    [Fact]
    public void UpdateTaskStatus_ShouldUpdateStatus()
    {
        // Arrange
        TaskManager taskManager = new TaskManager();
        Task task = new Task("T001", "Test Task", DateTime.Now.AddDays(1), "High", "John Doe", "To-Do");
        taskManager.AddTask(task);

        // Act
        taskManager.UpdateTaskStatus("T001", "Done");

        // Assert
        Assert.Equal("Done", task.Status);
    }

    [Fact]
    public void SearchTask_ShouldReturnCorrectTask()
    {
        // Arrange
        TaskManager taskManager = new TaskManager();
        Task task = new Task("T001", "Test Task", DateTime.Now.AddDays(1), "High", "John Doe", "To-Do");
        taskManager.AddTask(task);

        // Act
        var foundTask = taskManager.SearchTask("T001");

        // Assert
        Assert.Equal(task, foundTask);
    }
}

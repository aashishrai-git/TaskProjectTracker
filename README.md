# Task & Project Tracker

A C# console-based application for managing tasks and projects, allowing users to add, update, search, sort, and generate reports on tasks with persistence and logging.

## Features

- **Task Management**: Add, update status, search, and sort tasks by due date.
- **Status Tracking**: Track tasks as To-Do, In Progress, or Done.
- **Reporting**: Generate CSV reports on tasks.
- **Persistence**: Save and load tasks from JSON file.
- **Logging**: Log actions to a TXT file.
- **Error Handling**: Graceful handling of invalid inputs and file errors.
- **Unit Testing**: xUnit tests for core functionalities.

## Project Structure

- `Task.cs`: Defines the Task class with properties and constructor.
- `TaskManager.cs`: Manages the list of tasks, provides methods for CRUD operations, sorting, reporting, persistence, and logging.
- `Program.cs`: Main entry point with console menu interface.
- `TaskManagerTests.cs`: Unit tests for TaskManager methods.

## Dependencies

- .NET 8.0
- Newtonsoft.Json (for JSON serialization)
- xUnit (for unit testing)

## How to Build and Run

1. Ensure .NET 8.0 SDK is installed.
2. Navigate to the project directory: `cd TaskProjectTracker`
3. Restore packages: `dotnet restore`
4. Build the project: `dotnet build`
5. Run the application: `dotnet run`

## How to Test

### Unit Tests
Run the unit tests to verify core functionalities:
```
dotnet test
```
Tests cover adding tasks, updating status, and searching tasks.

### Manual Testing
1. **Run the App**: Start with `dotnet run`.
2. **Add a Task**: Choose option 1, enter details (ID, Name, Due Date YYYY-MM-DD, Priority, Assignee, Status).
3. **Update Status**: Choose option 2, enter Task ID and new status.
4. **Search Task**: Choose option 3, enter Task ID or Assignee.
5. **Sort by Due Date**: Choose option 4.
6. **Generate Report**: Choose option 5, check `task_report.csv` in the project directory.
7. **Exit**: Choose option 6, tasks are saved to `tasks.json`.

### Persistence Testing
- Add tasks and exit.
- Restart the app; tasks should load automatically.
- Check `tasks.json` for saved data.

### Logging Testing
- Perform actions like adding/updating tasks.
- Check `task_log.txt` for logged entries with timestamps.

### Error Handling Testing
- Enter invalid date (e.g., "abc") when adding task; should handle gracefully.
- Search for non-existent task; should display "Task not found."
- Try loading without `tasks.json`; should not crash.



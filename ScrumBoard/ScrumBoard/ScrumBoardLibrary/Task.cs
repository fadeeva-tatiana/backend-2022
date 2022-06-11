namespace ScrumBoardLibrary.Task;

public class Task : ITask
{
    public Task(string title, string description, TaskPriority priority)
    {
        ID = Guid.NewGuid().ToString();
        Title = title;
        Description = description;
        Priority = priority;
    }

    public string ID { get; }

    public string Title { get; set; }

    public string Description { get; set; }

    public TaskPriority Priority { get; set; }
}
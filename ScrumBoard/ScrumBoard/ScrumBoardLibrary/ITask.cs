namespace ScrumBoardLibrary.Task;

public enum TaskPriority
{
    HARD,
    MEDIUM,
    EASY,
    NONE
}

public interface ITask
{
    public string ID { get; }

    public string Title { get; set; }

    public string Description { get; set; }

    public TaskPriority Priority { get; set; }
}
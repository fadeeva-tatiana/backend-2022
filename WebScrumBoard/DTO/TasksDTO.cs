using ScrumBoard.Body;

namespace TasksDTO;

public class CreateTaskDTO
{
    public string? Title { get; set; }
    public int Priority { get; set; }
    public string? Description { get; set; }
}

public class EditTaskDTO
{
    public string? Title { get; set; }
    public int Priority { get; set; }
    public string? Description { get; set; }
    public string? ID { get; set; }
}

public class MoveTaskDTO
{
    public string? columnID { get; set; }
}

public class TaskDTO
{
    public TaskDTO(TaskInterface task)
    {
        ID = task.Identifier;
        Title = task.Title;
        Description = task.Description;
        Priority = task.Priority.ToString();
    }
    public string Title { get; set; }
    public string Priority { get; set; }
    public string Description { get; set; }
    public string ID { get; set; }
}
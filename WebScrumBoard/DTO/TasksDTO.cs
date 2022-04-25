using ScrumBoard.Creator;
using ScrumBoard.Body;

namespace TasksDTO;

public class CreateTaskDTO
{
    public string? Name { get; set; }
    public int Priority { get; set; }
    public string? Description { get; set; }
}

public class EditTaskDTO
{
    public string? Name { get; set; }
    public int Priority { get; set; }
    public string? Description { get; set; }
    public string? GUID { get; set; }
}

public class MoveTaskDTO
{
    public string? columnGUID { get; set; }
}

public class TaskDTO
{
    public TaskDTO(TasksInterface task)
    {
        GUID = task.GUID;
        Name = task.Name;
        Description = task.Description;
        Priority = task.Priority.ToString();
    }
    public string Name { get; set; }
    public string Priority { get; set; }
    public string Description { get; set; }
    public string GUID { get; set; }
}
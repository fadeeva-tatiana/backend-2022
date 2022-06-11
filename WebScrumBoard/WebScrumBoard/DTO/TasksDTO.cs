using ScrumBoardLibrary.Task;

namespace WebScrumBoard2.DTO;

public class TasksDTO
{
    public TasksDTO(ITask task)
    {
        ID = task.ID;
        TaskTitle = task.Title;
        TaskDescription = task.Description;
        TaskPriority = task.Priority.ToString();
    }

    public string ID { get; set; }
    public string TaskTitle { get; set; }
    public string TaskDescription { get; set; }
    public string TaskPriority { get; set; }
}
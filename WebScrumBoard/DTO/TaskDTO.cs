using ScrumBoard.Tasks;

namespace ScrumBoardAPI.DTO;

public class TaskDTO
{
    public TaskDTO(TaskInterface task)
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
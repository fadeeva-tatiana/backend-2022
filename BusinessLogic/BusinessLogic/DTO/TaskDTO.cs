using ScrumBoardLibrary;

namespace BisnessLogicStratum.DTO;

public class TaskDTO
{
    public int ID { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public int Priority { get; set; }

    public TaskDTO(ITask task)
    {
        ID = task.ID;
        Title = task.Title;
        Description = task.Description;
        Priority = task.Priority;
    }
}
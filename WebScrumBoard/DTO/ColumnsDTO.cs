using ScrumBoard.Body;
using TasksDTO;

namespace WebScrumBoard.DTO;

public class ColumnsDTO
{
    public ColumnsDTO(ColumnInterface column)
    {
        ID = column.Identifier;
        Title = column.Title;
        Tasks = column.Find_tasks().Select(task => new TaskDTO(task));
    }

    public string ID { get; set; }
    public string Title { get; set; }
    public IEnumerable<TaskDTO> Tasks { get; set; }
}

public class EditColumnDTO
{
    public string? ID { get; set; }
    public string? Title { get; set; }
}

public class CreateColumnDTO
{
    public string? Title { get; set; }
}
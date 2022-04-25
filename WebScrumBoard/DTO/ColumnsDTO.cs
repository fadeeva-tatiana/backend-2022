using ScrumBoard.Body;
using TasksDTO;

namespace WebScrumBoard.DTO;

public class ColumnsDTO
{
    public ColumnsDTO(ColumnInterface column)
    {
        GUID = column.GUID;
        Name = column.Title;
        Tasks = column.Find_tasks().Select(task => new TaskDTO(task));
    }

    public string GUID { get; set; }

    public string Name { get; set; }

    public IEnumerable<TaskDTO> Tasks { get; set; }
}

public class EditColumnDTO
{
    public string? GUID { get; set; }
    public string? Name { get; set; }
}

public class CreateColumnDTO
{
    public string? Name { get; set; }
}
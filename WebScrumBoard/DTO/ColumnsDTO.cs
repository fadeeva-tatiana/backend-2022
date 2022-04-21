using ScrumBoard.Columns;

namespace ScrumBoardAPI.DTO;

public class ColumnsDTO
{
    public ColumnsDTO(ColumnInterface column)
    {
        GUID = column.GUID;
        Name = column.Name;
        Tasks = column.Get_all_task().Select(task => new TaskDTO(task));
    }

    public string GUID { get; set; }

    public string Name { get; set; }

    public EnumerableInterface<TaskDTO> Tasks { get; set; }
}
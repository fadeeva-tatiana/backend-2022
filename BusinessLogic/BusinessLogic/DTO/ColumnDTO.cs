using ScrumBoardLibrary;

namespace BisnessLogicStratum.DTO;

public class ColumnDTO
{
    public int ID { get; set; }
    public string Title { get; set; }

    public List<ITask> Tasks { get; set; }

    public ColumnDTO(IColumn column)
    {
        ID = column.ID;
        Title = column.ColumnTitle;

        Tasks = new List<ITask>(column.GetAllTasks());
    }
}
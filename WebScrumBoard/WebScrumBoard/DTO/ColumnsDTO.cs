using ScrumBoardLibrary.Column;
using ScrumBoardLibrary.Task;

namespace WebScrumBoard2.DTO;

public class ColumnsDTO
{
    public ColumnsDTO(IColumn column)
    {
        ID = column.ID;
        ColumnTitle = column.Title;

        List<TasksDTO> listTasksDTO = new List<TasksDTO>();
        List<ITask> listTasks = column.GetAllTask();

        foreach (ITask task in listTasks)
        {
            listTasksDTO.Add(new TasksDTO(task));
        }

        Tasks = listTasksDTO;
    }

    public string ID { get; set; }
    public string ColumnTitle { get; set; }
    public IEnumerable<TasksDTO> Tasks { get; set; }
}
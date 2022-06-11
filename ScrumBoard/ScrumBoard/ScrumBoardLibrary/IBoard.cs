using ScrumBoardLibrary.Column;
using ScrumBoardLibrary.Task;

namespace ScrumBoardLibrary.Board;

public interface IBoard
{
    public string ID { get; }

    public string Title { get; set; }

    public void AddColumn(IColumn column);

    public void EditColumnTitle(string ID, string title);

    public void AddTask(ITask task, int columnNum = 0);

    public ITask GetTask(string ID);

    public IColumn GetColumn(string ID);

    public List<IColumn> GetAllColumn();

    public void EditTask(string ID, string title, string description, TaskPriority priority);

    public void DeleteTask(string ID);

    public void DeleteColumn(string ID);

    public void MoveTask(string finalColumnID, string taskID);
}
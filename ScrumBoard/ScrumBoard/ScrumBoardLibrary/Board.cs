using ScrumBoard.Exception;
using ScrumBoardLibrary.Column;
using ScrumBoardLibrary.Task;

namespace ScrumBoardLibrary.Board;

public class Board : IBoard
{
    public Board(string title)
    {
        ID = Guid.NewGuid().ToString();
        Title = title;
        _columnList = new List<IColumn>();
    }

    private const int MAX_COL = 10;

    private readonly List<IColumn> _columnList;

    public string ID { get; }

    public string Title { get; set; }

    public void AddColumn(IColumn column)
    {
        if (_columnList.Count >= MAX_COL)
        {
            throw new ColumnsLimitException();
        }
        if (_columnList.Contains(column))
        {
            throw new ColumnExistException();
        }
        _columnList.Add(column);
    }

    public void EditColumnTitle(string ID, string title)
    {
        for (int i = 0; i < _columnList.Count; i++)
        {
            if (_columnList[i].ID == ID)
            {
                _columnList[i].Title = title;
                return;
            }
        }
        throw new ColumnNotFoundException();
    }

    public void AddTask(ITask task, int columnNum = 0)
    {
        if (columnNum < 0 || columnNum >= _columnList.Count)
        {
            throw new ColumnNotFoundException();
        }
        _columnList[columnNum].AddTask(task);
    }

    public ITask GetTask(string ID)
    {
        for (int i = 0; i < _columnList.Count; i++)
        {
            ITask? result = _columnList[i].GetTask(ID);
            if (result != null)
            {
                return result;
            }
        }
        throw new TaskNotFoundException();
    }

    public IColumn GetColumn(string ID)
    {
        for (int i = 0; i < _columnList.Count; i++)
        {
            if (_columnList[i].ID == ID)
            {
                return _columnList[i];
            }
        }
        throw new ColumnNotFoundException();
    }

    public List<IColumn> GetAllColumn()
    {
        return _columnList;
    }

    public void EditTask(string ID, string title, string description, TaskPriority priority)
    {
        for (int i = 0; i < _columnList.Count; i++)
        {
            if (_columnList[i].EditTask(ID, title, description, priority))
            {
                return;
            }
        }
        throw new TaskNotFoundException();
    }

    public void DeleteTask(string ID)
    {
        for (int i = 0; i < _columnList.Count; i++)
        {
            if (_columnList[i].DeleteTask(ID))
            {
                return;
            }
        }
        throw new TaskNotFoundException();
    }

    public void DeleteColumn(string ID)
    {
        for (int i = 0; i < _columnList.Count; i++)
        {
            if (_columnList[i].ID == ID)
            {
                _columnList.RemoveAt(i);
                return;
            }
        }
        throw new ColumnNotFoundException();
    }

    public void MoveTask(string finalColumnID, string taskID)
    {
        ITask task = GetTask(taskID);
        DeleteTask(task.ID);
        AddTask(task, GetNumColumn(finalColumnID));
    }

    private int GetNumColumn(string ID)
    {
        for (int i = 0; i < _columnList.Count; i++)
        {
            if (_columnList[i].ID == ID)
            {
                return i;
            }
        }
        throw new ColumnNotFoundException();
    }
}
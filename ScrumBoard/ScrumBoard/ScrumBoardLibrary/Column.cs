using ScrumBoard.Exception;
using ScrumBoardLibrary.Task;

namespace ScrumBoardLibrary.Column;

public class Column : IColumn
{
    public Column(string title)
    {
        ID = Guid.NewGuid().ToString();
        Title = title;
        _tasksList = new List<ITask>();
    }

    public string ID { get; }

    public string Title { get; set; }

    private readonly List<ITask> _tasksList;

    public void AddTask(ITask task)
    {
        if (_tasksList.Contains(task))
        {
            throw new TaskExistException();
        }
        _tasksList.Add(task);
    }

    public ITask? GetTask(string ID)
    {
        for (int i = 0; i < _tasksList.Count; i++)
        {
            if (_tasksList[i].ID == ID)
            {
                return _tasksList[i];
            }
        }
        return null;
    }

    public bool EditTask(string ID, string title, string description, TaskPriority priority)
    {
        for (int i = 0; i < _tasksList.Count; i++)
        {
            if (_tasksList[i].ID == ID)
            {
                _tasksList[i].Title = title;
                _tasksList[i].Description = description;
                _tasksList[i].Priority = priority;
                return true;
            }
        }
        return false;
    }

    public bool DeleteTask(string ID)
    {
        for (int i = 0; i < _tasksList.Count; i++)
        {
            if (_tasksList[i].ID == ID)
            {
                _tasksList.RemoveAt(i);
                return true;
            }
        }
        return false;
    }

    public List<ITask> GetAllTask()
    {
        return _tasksList;
    }

    public void DeleteAllTask()
    {
        _tasksList.Clear();
    }
}
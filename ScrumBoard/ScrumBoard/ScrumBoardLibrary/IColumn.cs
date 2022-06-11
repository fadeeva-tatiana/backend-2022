using ScrumBoardLibrary.Task;

namespace ScrumBoardLibrary.Column;

public interface IColumn
{
    public string ID { get; }

    public string Title { get; set; }

    public void AddTask(ITask task);

    public ITask? GetTask(string ID);

    public bool EditTask(string ID, string title, string description, TaskPriority priority);

    public bool DeleteTask(string ID);

    public List<ITask> GetAllTask();

    public void DeleteAllTask();
}
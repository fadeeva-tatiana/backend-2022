using Microsoft.Extensions.Caching.Memory;
using ScrumBoardLibrary;
using Task = ScrumBoardLibrary.Task;

namespace DataAccessStratum.Repositories;

public class TaskRepository : ITaskRepository
{
    private readonly IMemoryCache _memoryCache;
    private readonly IBoardRepository _boardRepository;

    public TaskRepository(IMemoryCache memoryCache, IBoardRepository boardRepository)
    {
        _memoryCache = memoryCache;
        _boardRepository = boardRepository;
    }

    public List<ITask> GetAllTasks()
    {
        _memoryCache.TryGetValue("tasks", out List<ITask> tasks);
        return tasks;
    }

    public ITask Get(int ID)
    {
        return GetAllTasks().Find(t => t.ID == ID);
    }

    public void Create(int boardID, int ID, string title, string description, int prioriry)
    {
        var tasks = GetAllTasks();

        if (tasks is null) tasks = new List<ITask>();

        var task = new Task(ID, title, description, priority);
        tasks.Add(task);

        var board = _boardRepository.Get(boardID);
        board.AddTask(task);


        _memoryCache.Set("tasks", tasks);
    }

    public void Remove(int boardID, int ID)
    {
        var tasks = GetAllTasks();
        for (int i = 0; i < tasks.Count; i++)
            if (tasks[i].ID == ID)
            {
                tasks.RemoveAt(i);
                break;
            }

        foreach (var col in _boardRepository.Get(boardID).Columns)
        {
            var task = col.GetAllTasks().Find(t => t.ID == ID);
            if (task is not null)
                col.GetAllTasks().Remove(task);
        }



        _memoryCache.Set("tasks", tasks);
    }

    public void Edit(int taskID, string? newTitle, string? newDescription, int? newPriority)
    {
        var task = Get(taskID);
        task.Title = newTitle ?? task.Title;
        task.Description = newDescription ?? task.Description;
        task.Priority = newPriority ?? task.Priority;
    }

    public void Move(int boardID, int taskID, int colToID)
    {
        var task = Get(taskID);
        Remove(boardID, taskID);
        var col = _boardRepository.Get(boardID).Columns.Find(c => c.ID == colToID);
        col.AddTask(task);

    }
}
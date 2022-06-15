using BisnessLogicStratum.DTO;
using BisnessLogicStratum.Interfaces;
using DataAccessStratum.Repositories;

namespace BisnessLogicStratum.Services;

public class TaskService : ITaskService
{
    private readonly ITaskRepository _repository;

    public TaskService(ITaskRepository repository)
    {
        this._repository = repository;
    }

    public List<TaskDTO> GetAllTasks()
    {
        var tasks = _repository.GetAllTasks();
        var tasksDTO = tasks.Select(c => new TaskDTO(c)).ToList();
        return tasksDTO;
    }

    public void CreateTask(int boardID, int ID, string title, string description, int priority)
    {
        this._repository.Create(boardID, ID, title, description, priority);
    }

    public TaskDTO GetTask(int ID)
    {
        return new TaskDTO(_repository.GetAllTasks().Find(c => c.ID == ID));
    }

    public void RemoveTask(int boardID, int ID)
    {
        this._repository.Remove(boardID, ID);
    }

    public void EditTask(int taskID, string? newTitle, string? newDescription, int? newPriority)
    {
        _repository.Edit(taskID, newTitle, newDescription, newPriority);
    }

    public void MoveTask(int boardID, int taskID, int colToID)
    {
        _repository.Move(boardID, taskID, colToID);
    }
}
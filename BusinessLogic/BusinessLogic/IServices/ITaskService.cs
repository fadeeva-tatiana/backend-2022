using BisnessLogicStratum.DTO;

namespace BisnessLogicStratum.Interfaces;

public interface ITaskService
{
    List<TaskDTO> GetAllTasks();
    public void CreateTask(int boardID, int ID, string title, string description, int priority);
    public TaskDTO GetTask(int ID);
    public void RemoveTask(int boardID, int ID);
    void EditTask(int taskID, string? newTitle, string? newDescription, int? newPriority);
    void MoveTask(int boardID, int taskID, int colToID);
}
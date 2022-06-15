using ScrumBoardLibrary;

namespace DataAccessStratum.Repositories;

public interface ITaskRepository
{
    List<ITask> GetAllTasks();
    ITask Get(int ID);
    void Create(int boardID, int ID, string title, string description, int priority);
    void Remove(int boardID, int ID);
    void Edit(int taskID, string? newTitle, string? newDescription, int? newPriority);
    void Move(int boardID, int taskID, int colToID);
}
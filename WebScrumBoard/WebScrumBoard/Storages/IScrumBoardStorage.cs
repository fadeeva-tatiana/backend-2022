using WebScrumBoard2.DTO;

namespace WebScrumBoard2.Models;

public interface IScrumBoardStorage
{
    public void AddBoard(CreateBoardDTO arg);
    public void AddColumn(string boardID, CreateColumnDTO arg);
    public void AddTask(string columnID, CreateTaskDTO arg);

    public BoardDTO GetBoard(string boardID);

    public void DeleteBoard(string boardID);
    public void DeleteTask(string columnID, string taskID);

    public IEnumerable<BoardDTO> GetAllBoard();
    public void MoveTask(string boardID, string taskID, MoveTaskDTO arg);
}
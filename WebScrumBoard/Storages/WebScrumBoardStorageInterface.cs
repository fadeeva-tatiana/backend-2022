using TasksDTO;
using WebScrumBoard.DTO;

namespace WebScrumBoard.Models;

public interface WebScrumBoardStorageInterface
{
    public BoardDTO Get_board(string id);

    public IEnumerable<BoardDTO> GetAllBoard();

    public void Add_board(CreateBoardDTO param);
    public void Remove_board(string boardID);
    public void Add_column(string boardID, CreateColumnDTO param);
    public void Edit_column(string boardID, EditColumnDTO param);
    public void Add_task(string boardID, CreateTaskDTO param);
    public void Edit_task(string boardID, EditTaskDTO param);
    public void Remove_task(string boardID, string taskID);
    public void Move_task(string boardID, string taskID, MoveTaskDTO param);
}
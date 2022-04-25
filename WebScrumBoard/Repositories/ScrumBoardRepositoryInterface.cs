using TasksDTO;
using WebScrumBoard.DTO;

namespace WebScrumBoard.Models;

public interface ScrumBoardRepositoryInterface
{
    public void Add_board(CreateBoardDTO param);

    public BoardDTO Get_board(string guid);

    public IEnumerable<BoardDTO> GetAllBoard();

    public void Remove_board(string boardGUID);


    public void Add_column(string boardGUID, CreateColumnDTO param);

    public void Edit_column(string boardGUID, EditColumnDTO param);

    public void Remove_column(string boardGUID, string columnGUID);


    public void Add_task(string boardGUID, CreateTaskDTO param);

    public void Edit_task(string boardGUID, EditTaskDTO param);

    public void Remove_task(string boardGUID, string taskGUID);

    public void Move_task(string boardGUID, string taskGUID, MoveTaskDTO param);
}
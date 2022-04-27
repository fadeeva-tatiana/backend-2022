using Microsoft.Extensions.Caching.Memory;
using Task = ScrumBoard.Creator;
using WebScrumBoard.DTO;
using TasksDTO;
using ScrumBoard.Body;

namespace WebScrumBoard.Models;

public class WebScrumBoardStorage : WebScrumBoardStorageInterface
{
    private readonly IMemoryCache _memoryCache;

    public WebScrumBoardStorage(IMemoryCache memoryCache)
    {
        _memoryCache = memoryCache;
    }

    public void Add_board(CreateBoardDTO param)
    {
        List<BoardInterface> boards;
        {
            boards = new List<BoardInterface>();
        }

        boards.Add(new Board(param.Title));

        _memoryCache.Set("boards", boards);
    }

    public BoardDTO Get_board(string boardID)
    {
        return new BoardDTO(GetListBoards()[Get_index_board(boardID)]);
    }

    public IEnumerable<BoardDTO> GetAllBoard()
    {
        return GetListBoards().Select(board => new BoardDTO(board));
    }

    public void Remove_board(string boardID)
    {
        List<BoardInterface> boards = GetListBoards();

        for (int i = 0; i < boards.Count; i++)
        {
            if (boards[i].Identifier == boardID)
            {
                boards.RemoveAt(i);
                _memoryCache.Set("boards", boards);
                return;
            }
        }
    }

    public void Add_column(string boardID, CreateColumnDTO param)
    {
        List<BoardInterface> boards = GetListBoards();

        boards[Get_index_board(boardID)].Add_column(new Column(param.Title));

        _memoryCache.Set("boards", boards);
    }

    public void Edit_column(string boardID, EditColumnDTO param)
    {
        List<BoardInterface> boards = GetListBoards();

        boards[Get_index_board(boardID)].Rename_column(param.ID, param.Title);

        _memoryCache.Set("boards", boards);
    }

    public void Add_task(string boardID, CreateTaskDTO param)
    {
        List<BoardInterface> boards = GetListBoards();

        boards[Get_index_board(boardID)].Add_task_to_column(
            new Task(param.Title, param.Description, GetTaskPriority(param.Priority))
        );

        _memoryCache.Set("boards", boards);
    }

    public void Remove_task(string boardID, string taskID)
    {
        List<BoardInterface> boards = GetListBoards();

        boards[Get_index_board(boardID)].Delete_task(taskID);

        _memoryCache.Set("boards", boards);
    }

    public void Edit_task(string boardID, EditTaskDTO param)
    {
        List<BoardInterface> boards = GetListBoards();

        boards[Get_index_board(boardID)].Edit_task(
            param.ID, param.Title, param.Description, GetTaskPriority(param.Priority)
        );

        _memoryCache.Set("boards", boards);
    }

    public void Move_task(string boardID, string taskID, MoveTaskDTO param)
    {
        List<BoardInterface> boards = GetListBoards();

        boards[Get_index_board(boardID)].Move_task(param.columnID, taskID);

        _memoryCache.Set("boards", boards);
    }

    private int Get_index_board(string boardID)
    {
        List<BoardInterface> boards = GetListBoards();

        for (int i = 0; i < boards.Count; i++)
        {
            if (boards[i].Identifier == boardID)
            {
                return i;
            }
        }
    }

    private List<BoardInterface> GetListBoards()
    {
        _memoryCache.TryGetValue("boards", out List<BoardInterface> boards);
        return boards;
    }

    private static Task_priority GetTaskPriority(int priority)
    {
        return priority switch
        {
            0 => Task_priority.EASY,
            1 => Task_priority.MEDIUM,
            2 => Task_priority.HARD,
        };
    }
}
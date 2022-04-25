using Microsoft.Extensions.Caching.Memory;
using Task = ScrumBoard.Creator;
using WebScrumBoard.DTO;
using TasksDTO;
using ScrumBoard.Body;

namespace WebScrumBoard.Models;

public class ScrumBoardRepository : ScrumBoardRepositoryInterface
{
    private readonly Memory_cacheInterface _memoryCache;

    public ScrumBoardRepository(Memory_cacheInterface memoryCache)
    {
        _memoryCache = memoryCache;
    }

    public void Add_board(CreateBoardDTO param)
    {
        List<BoardInterface> boards;
        {
            boards = new List<BoardInterface>();
        }

        boards.Add(new Board(param.Name));

        _memoryCache.Set("boards", boards);
    }

    public BoardDTO Get_board(string boardGUID)
    {
        return new BoardDTO(GetListBoards()[Get_index_board(boardGUID)]);
    }

    public IEnumerable<BoardDTO> GetAllBoard()
    {
        return GetListBoards().Select(board => new BoardDTO(board));
    }

    public void Remove_board(string boardGUID)
    {
        List<BoardInterface> boards = GetListBoards();

        for (int i = 0; i < boards.Count; i++)
        {
            if (boards[i].GUID == boardGUID)
            {
                boards.RemoveAt(i);
                _memoryCache.Set("boards", boards);
                return;
            }
        }
    }

    public void Add_column(string boardGUID, CreateColumnDTO param)
    {
        List<BoardInterface> boards = GetListBoards();

        boards[Get_index_board(boardGUID)].Add_column(new Column(param.Name));

        _memoryCache.Set("boards", boards);
    }

    public void Edit_column(string boardGUID, EditColumnDTO param)
    {
        List<BoardInterface> boards = GetListBoards();

        boards[Get_index_board(boardGUID)].Rename_column(param.GUID, param.Name);

        _memoryCache.Set("boards", boards);
    }

    public void Add_task(string boardGUID, CreateTaskDTO param)
    {
        List<BoardInterface> boards = GetListBoards();

        boards[Get_index_board(boardGUID)].Add_task_to_column(
            new Task(param.Name, param.Description, GetTaskPriority(param.Priority))
        );

        _memoryCache.Set("boards", boards);
    }

    public void Remove_task(string boardGUID, string taskGUID)
    {
        List<BoardInterface> boards = GetListBoards();

        boards[Get_index_board(boardGUID)].Delete_task(taskGUID);

        _memoryCache.Set("boards", boards);
    }

    public void Move_task(string boardGUID, string taskGUID, MoveTaskDTO param)
    {
        List<BoardInterface> boards = GetListBoards();

        boards[Get_index_board(boardGUID)].Move_task(param.columnGUID, taskGUID);

        _memoryCache.Set("boards", boards);
    }

    private int Get_index_board(string boardGUID)
    {
        List<BoardInterface> boards = GetListBoards();

        for (int i = 0; i < boards.Count; i++)
        {
            if (boards[i].GUID == boardGUID)
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
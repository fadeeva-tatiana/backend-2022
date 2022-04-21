using Microsoft.Extensions.Caching.Memory;
using ScrumBoard.Board;
using ScrumBoard.Columns;
using ScrumBoard.Tasks;
using Task = ScrumBoard.Tasks.Task;
using ScrumBoardAPI.DTO;

namespace ScrumBoardAPI.Models;

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
        try
        {
            boards = Get_list_boards();
        }
        catch (ListBoardsIsEmptyException)
        {
            boards = new List<BoardInterface>();
        }

        boards.Add(new Board(param.Name));

        _memoryCache.Set("boards", boards);
    }

    public BoardDTO Get_board(string boardGUID)
    {
        return new BoardDTO(GetListBoards()[GetIndexBoard(boardGUID)]);
    }

    public EnumerableInterface<BoardDTO> GetAllBoard()
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
        throw new BoardNotFoundException();
    }

    public void Add_column(string boardGUID, CreateColumnDTO param)
    {
        List<BoardInterface> boards = GetListBoards();

        boards[GetIndexBoard(boardGUID)].Add_column(new Column(param.Name));

        _memoryCache.Set("boards", boards);
    }

    public void Edit_column(string boardGUID, EditColumnDTO param)
    {
        List<BoardInterface> boards = GetListBoards();

        boards[GetIndexBoard(boardGUID)].EditColumnName(param.GUID, param.Name);

        _memoryCache.Set("boards", boards);
    }

    public void Remove_column(string boardGUID, string columnGUID)
    {
        List<BoardInterface> boards = GetListBoards();

        boards[GetIndexBoard(boardGUID)].DeleteColumn(columnGUID);

        _memoryCache.Set("boards", boards);
    }


    public void Add_task(string boardGUID, CreateTaskDTO param)
    {
        List<BoardInterface> boards = GetListBoards();

        boards[GetIndexBoard(boardGUID)].AddTask(
            new Task(param.Name, param.Description, GetTaskPriority(param.Priority))
        );

        _memoryCache.Set("boards", boards);
    }

    public void Edit_task(string boardGUID, EditTaskDTO param)
    {
        List<BoardInterface> boards = GetListBoards();

        boards[GetIndexBoard(boardGUID)].EditTask(
            param.GUID, param.Name, param.Description, GetTaskPriority(param.Priority)
        );

        _memoryCache.Set("boards", boards);
    }

    public void Remove_task(string boardGUID, string taskGUID)
    {
        List<BoardInterface> boards = GetListBoards();

        boards[GetIndexBoard(boardGUID)].DeleteTask(taskGUID);

        _memoryCache.Set("boards", boards);
    }

    public void Move_task(string boardGUID, string taskGUID, TransferTaskDTO param)
    {
        List<IBoard> boards = GetListBoards();

        boards[GetIndexBoard(boardGUID)].TransferTask(param.columnGUID, taskGUID);

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
        throw new BoardNotFoundException();
    }

    private List<BoardInterface> GetListBoards()
    {
        _memoryCache.TryGetValue("boards", out List<BoardInterface> boards);

        if (boards == null)
        {
            throw new ListBoardsIsEmptyException();
        }
        return boards;
    }

    private static Task_priority GetTaskPriority(int priority)
    {
        return priority switch
        {
            0 => Task_priority.EASY,
            1 => Task_priority.MEDIUM,
            2 => Task_priority.HARD,
            _ => throw new UndefinedPriorityException(),
        };
    }
}
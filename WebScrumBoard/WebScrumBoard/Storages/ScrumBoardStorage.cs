using ScrumBoardLibrary.Board;
using ScrumBoardLibrary.Column;
using ScrumBoardLibrary.Task;
using WebScrumBoard2.DTO;
using Microsoft.Extensions.Caching.Memory;
using Task = ScrumBoardLibrary.Task.Task;


namespace WebScrumBoard2.Models;

public class ScrumBoardStorage : IScrumBoardStorage
{
    private readonly IMemoryCache _memoryCache;
    public ScrumBoardStorage(IMemoryCache memoryCache)
    {
        _memoryCache = memoryCache;
    }

    private static TaskPriority GetTaskPriority(int priority)
    {
        switch (priority)
        {
            case 0:
                priority = (int)TaskPriority.HARD;
                break;
            case 1:
                priority = (int)TaskPriority.MEDIUM;
                break;
            case 2:
                priority = (int)TaskPriority.EASY;
                break;
            default:
                priority = (int)TaskPriority.NONE;
                break;
        }
        return (TaskPriority)priority;
    }

    private List<IBoard> GetListBoards()
    {
        _memoryCache.TryGetValue("boards", out List<IBoard> listBoards);

        if (listBoards == null)
            throw new System.Exception("Невозможно выполнить действие! Список досок пуст.");

        return listBoards;
    }

    private int GetIndexBoard(string boardID)
    {
        List<IBoard> listBoards = GetListBoards();
        int listBoardsLength = listBoards.Count;

        for (int i = 0; i < listBoardsLength; i++)
        {
            if (listBoards[i].ID == boardID)
                return i;
        }
        throw new System.Exception("Доска не найдена.");
    }
    public void AddBoard(CreateBoardDTO arg)
    {
        List<IBoard> listBoards;
        try
        {
            listBoards = GetListBoards();
        }
        catch (System.Exception)
        {
            listBoards = new List<IBoard>();
        }

        listBoards.Add(new Board(arg.BoardTitle));
        _memoryCache.Set("boards", listBoards);
    }

    public void AddColumn(string boardID, CreateColumnDTO arg)
    {
        List<IBoard> listBoards = GetListBoards();
        listBoards[GetIndexBoard(boardID)].AddColumn(new Column(arg.ColumnTitle));
        _memoryCache.Set("boards", listBoards);
    }

    public void AddTask(string boardID, CreateTaskDTO arg)
    {
        List<IBoard> listBoards = GetListBoards();
        listBoards[GetIndexBoard(boardID)].AddTask(new Task(arg.TaskTitle, arg.TaskDescription, GetTaskPriority(arg.TaskPriority)));
        _memoryCache.Set("boards", listBoards);
    }
    public BoardDTO GetBoard(string boardID)
    {
        BoardDTO board = new(GetListBoards()[GetIndexBoard(boardID)]);
        return board;
    }

    public void DeleteBoard(string boardID)
    {
        List<IBoard> listBoards = GetListBoards();
        int listBoardsLength = listBoards.Count;

        for (int i = 0; i < listBoardsLength; i++)
        {
            if (listBoards[i].ID == boardID)
            {
                listBoards.RemoveAt(i);
                _memoryCache.Set("boards", listBoards);
                return;
            }
        }

        throw new System.Exception("Доска не найдена.");
    }

    public void DeleteTask(string columnID, string taskID)
    {
        List<IBoard> listBoards = GetListBoards();
        listBoards[GetIndexBoard(columnID)].DeleteTask(taskID);
        _memoryCache.Set("boards", listBoards);
    }
    public IEnumerable<BoardDTO> GetAllBoard()
    {
        IEnumerable<BoardDTO> allBoards = GetListBoards().Select(board => new BoardDTO(board));
        return allBoards;
    }
    public void MoveTask(string boardID, string taskID, MoveTaskDTO arg)
    {
        List<IBoard> boards = GetListBoards();

        boards[GetIndexBoard(boardID)].MoveTask(arg.columnID, taskID);

        _memoryCache.Set("boards", boards);
    }
}

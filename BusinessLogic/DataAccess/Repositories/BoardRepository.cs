using Microsoft.Extensions.Caching.Memory;
using ScrumBoardLibrary;

namespace DataAccessStratum.Repositories;

public class BoardRepository : IBoardRepository
{
    private readonly IMemoryCache _memoryCache;

    public BoardRepository(IMemoryCache memoryCache)
    {
        _memoryCache = memoryCache;
    }

    public List<IBoard> GetAllBoards()
    {
        _memoryCache.TryGetValue("boards", out List<IBoard> boards);
        return boards;
    }

    public IBoard Get(int ID)
    {
        return GetAllBoards().Find(b => b.ID == ID);
    }

    public void Create(int ID, string title)
    {
        var boards = GetAllBoards();

        if (boards is null) boards = new List<IBoard>();

        var board = new Board(ID, title);
        boards.Add(board);

        _memoryCache.Set("boards", boards);
    }

    public void Remove(int ID)
    {
        var boards = GetAllBoards();
        for (int i = 0; i < boards.Count; i++)
            if (boards[i].ID == ID)
            {
                boards.RemoveAt(i);
                break;
            }

        _memoryCache.Set("boards", boards);
    }
}
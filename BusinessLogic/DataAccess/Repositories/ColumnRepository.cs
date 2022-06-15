using Microsoft.Extensions.Caching.Memory;
using ScrumBoardLibrary;

namespace DataAccessStratum.Repositories;

public class ColumnRepository : IColumnRepository
{
    private readonly IMemoryCache _memoryCache;
    private readonly IBoardRepository _boardRepository;

    public ColumnRepository(IMemoryCache memoryCache, IBoardRepository boardRepository)
    {
        _memoryCache = memoryCache;
        _boardRepository = boardRepository;
    }

    public List<IColumn> GetAllColumns()
    {
        _memoryCache.TryGetValue("columns", out List<IColumn> columns);
        return columns;
    }

    public IColumn Get(int ID)
    {
        return GetAllColumns().Find(c => c.ID == ID);
    }

    public void Create(int ID, string title)
    {
        var columns = GetAllColumns();

        if (columns is null) columns = new List<IColumn>();

        var col = new Column(ID, title);
        columns.Add(col);

        _memoryCache.Set("columns", columns);
    }

    public void Remove(int ID)
    {
        var columns = GetAllColumns();
        for (int i = 0; i < columns.Count; i++)
            if (columns[i].ID == ID)
            {
                columns.RemoveAt(i);
                break;
            }

        foreach (var board in _boardRepository.GetAllBoards())
        {
            var col = board.Columns.Find(c => c.ID == ID);
            if (col != null)
            {
                board.Columns.Remove(col);
                break;
            }
        }


        _memoryCache.Set("columns", columns);
    }

    public void Edit(int ID, string newTitle)
    {
        Get(ID).ColumnTitle = newTitle;

        foreach (var board in _boardRepository.GetAllBoards())
        {
            var col = board.Columns.Find(c => c.ID == ID);
            if (col is not null)
                col.ColumnTitle = newTitle;
        }
    }
}
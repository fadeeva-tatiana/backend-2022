using ScrumBoardLibrary;

namespace DataAccessStratum.Repositories;

public interface IColumnRepository
{
    List<IColumn> GetAllColumns();
    IColumn Get(int ID);
    void Create(int ID, string title);
    void Remove(int ID);
    void Edit(int ID, string newTitle);
}
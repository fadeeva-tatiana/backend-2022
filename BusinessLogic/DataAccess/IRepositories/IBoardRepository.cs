using ScrumBoardLibrary;

namespace DataAccessStratum.Repositories;

public interface IBoardRepository
{
    List<IBoard> GetAllBoards();
    IBoard Get(int ID);
    void Create(int ID, string title);
    void Remove(int ID);
}
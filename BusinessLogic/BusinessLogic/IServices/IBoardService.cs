using BisnessLogicStratum.DTO;

namespace BisnessLogicStratum.Interfaces;

public interface IBoardService
{
    List<BoardDTO> GetAllBoards();
    public void CreateBoard(int ID, string title);
    public BoardDTO GetBoard(int ID);
    public void RemoveBoard(int ID);
    public void AddColumn(int boardID, int columnID, string columnTitle);
}
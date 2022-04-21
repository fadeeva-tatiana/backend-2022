using ScrumBoard.Board;

namespace ScrumBoardAPI.DTO;

public class BoardDTO
{
    public BoardDTO(BoardInterface board)
    {
        GUID = board.GUID;
        Name = board.Name;
        Columns = board.GetAllColumn().Select(column => new ColumnsDTO(column));
    }

    public string GUID { get; set; }

    public string Name { get; set; }

    public EnumerableInterface<ColumnsDTO> Columns { get; set; }
}
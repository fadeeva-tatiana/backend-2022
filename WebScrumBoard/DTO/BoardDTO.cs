using ScrumBoard.Body;

namespace WebScrumBoard.DTO;

public class BoardDTO
{
    public BoardDTO(BoardInterface board)
    {
        GUID = board.GUID;
        Name = board.Title;
        Columns = board.Find_columns().Select(column => new ColumnsDTO(column));
    }

    public string GUID { get; set; }

    public string Name { get; set; }

    public IEnumerable<ColumnsDTO> Columns { get; set; }
}

public class CreateBoardDTO
{
    public string? Name { get; set; }
}
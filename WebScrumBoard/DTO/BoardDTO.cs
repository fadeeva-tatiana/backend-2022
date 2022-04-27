using ScrumBoard.Body;

namespace WebScrumBoard.DTO;

public class BoardDTO
{
    public BoardDTO(BoardInterface board)
    {
        ID = board.Identifier;
        Title = board.Title;
        Columns = board.Find_columns().Select(column => new ColumnsDTO(column));
    }

    public string ID { get; set; }
    public string Title { get; set; }
    public IEnumerable<ColumnsDTO> Columns { get; set; }
}

public class CreateBoardDTO
{
    public string? Title { get; set; }
}
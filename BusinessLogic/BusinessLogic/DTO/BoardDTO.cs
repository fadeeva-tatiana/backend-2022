using ScrumBoardLibrary;

namespace BisnessLogicStratum.DTO;

public class BoardDTO
{
    public int ID { get; set; }
    public string Title { get; set; }
    public List<ColumnDTO> Columns { get; set; }

    public BoardDTO(IBoard board)
    {
        ID = board.ID;
        Title = board.Title;
        Columns = board.Columns.Select(c => new ColumnDTO(c)).ToList();

    }
}
using ScrumBoardLibrary.Board;
using ScrumBoardLibrary.Column;

namespace WebScrumBoard2.DTO;

public class BoardDTO
{
    public BoardDTO(IBoard board)
    {
        ID = board.ID;
        BoardTitle = board.Title;

        List<ColumnsDTO> listColumnDTO = new List<ColumnsDTO>();
        List<IColumn> listColumn = board.GetAllColumn();

        foreach (IColumn column in listColumn)
        {
            listColumnDTO.Add(new ColumnsDTO(column));
        }
        Columns = listColumnDTO;
    }

    public string ID { get; set; }
    public string BoardTitle { get; set; }
    public IEnumerable<ColumnsDTO> Columns { get; set; }
}
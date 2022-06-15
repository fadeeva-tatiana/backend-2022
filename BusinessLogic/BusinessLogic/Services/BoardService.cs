using BisnessLogicStratum.DTO;
using BisnessLogicStratum.Interfaces;
using DataAccessStratum.Repositories;
using ScrumBoardLibrary;

namespace BisnessLogicStratum.Services;

public class BoardService : IBoardService
{
    private readonly IBoardRepository _repository;

    public BoardService(IBoardRepository repository)
    {
        this._repository = repository;
    }


    public List<BoardDTO> GetAllBoards()
    {
        var boards = _repository.GetAllBoards();
        var boardsDTO = boards.Select(b => new BoardDTO(b)).ToList();
        return boardsDTO;
    }

    public void CreateBoard(int ID, string title)
    {
        this._repository.Create(ID, title);
    }

    public BoardDTO GetBoard(int ID)
    {
        return new BoardDTO(_repository.GetAllBoards().Find(b => b.ID == ID));

    }

    public void RemoveBoard(int ID)
    {
        this._repository.Remove(ID);
    }

    public void AddColumn(int boardID, int columnID, string columnTitle)
    {
        _repository.Get(boardID).AddColumn(columnID, columnTitle);
    }
}